////using System;
////using System.Collections.Generic;
////using System.Linq;

////class Program
////{
////    private static List<string> names = new List<string>
////    {
////        "Anna", "зазаза", "помогите", "Andrew", "Banana", "Alan"
////    };
////    private static string currentSearch = string.Empty; // Переменная для хранения текущего ввода пользователя 

////    static void Main()
////    {
////        // Инициализация экрана 
////        Console.Clear();
////        DisplayList(names);

////        // Основной цикл для обработки ввода пользователя 
////        while (true)
////        {
////            // Обновление экрана с текущим поисковым запросом 
////            UpdateScreen();

////            // Показ приглашения и получение ввода пользователя 
////            Console.WriteLine("\nВведите строку для поиска (или 'exit' для завершения):");
////            Console.Write($"Поиск: '{currentSearch}'"); // Показываем текущий запрос 

////            ConsoleKeyInfo keyInfo;
////            while (true)
////            {
////                keyInfo = Console.ReadKey(intercept: true); // Читаем клавишу без отображения в консоли 

////                if (keyInfo.Key == ConsoleKey.Enter) // При нажатии Enter выходим из внутреннего цикла 
////                {
////                    Console.WriteLine(); // Для перевода строки после ввода 
////                    break;
////                }
////                else if (keyInfo.Key == ConsoleKey.Backspace) // При нажатии Backspace удаляем последний символ 
////                {
////                    if (currentSearch.Length > 0)
////                    {
////                        // Удаляем последний символ из текущего запроса 
////                        currentSearch = currentSearch.Remove(currentSearch.Length - 1);
////                        // Обновляем экран 
////                        UpdateScreen();
////                        // Убираем последний символ из консоли 
////                        Console.Write("\b \b"); // Удаляем последний символ в консоли 
////                    }
////                }
////                else if (keyInfo.Key == ConsoleKey.Escape) // При нажатии Escape очищаем текущий запрос 
////                {
////                    currentSearch = string.Empty;
////                    UpdateScreen();
////                }
////                else if (char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsWhiteSpace(keyInfo.KeyChar)) // Для ввода символов 
////                {
////                    currentSearch += keyInfo.KeyChar;
////                    Console.Write(keyInfo.KeyChar); // Отображаем символ в консоли 
////                }
////            }
////        }
////    }

////    // Метод для обновления экрана 
////    static void UpdateScreen()
////    {
////        Console.Clear();
////        DisplayList(names);
////        DisplayResults(SearchStrings(names, currentSearch), currentSearch);
////    }

////    // Метод для отображения списка строк 
////    static void DisplayList(List<string> list)
////    {
////        Console.WriteLine("Список строк:");
////        foreach (var name in list)
////        {
////            Console.WriteLine(name);
////        }
////    }

////    // Метод для отображения результатов поиска 
////    static void DisplayResults(List<string> results, string search)
////    {
////        Console.WriteLine($"\nРезультаты поиска по '{search}':");
////        if (results.Count > 0)
////        {
////            foreach (var result in results)
////            {
////                // Подсветка совпадений 
////                Console.WriteLine(result);
////            }
////        }
////        else
////        {
////            Console.WriteLine("Совпадений не найдено.");
////        }
////    }

////    // Функция для поиска строк 
////    static List<string> SearchStrings(List<string> list, string search)
////    {
////        return list.Where(s => s.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
////    }

////}
//using System;

//class Program
//{
//    static void Main()
//    {
//        // Определяем лабиринт (1 - стена, пробел - путь, '.' - сокровище)
//        char[,] maze = {
//            { '1', '1', '1', '1', '1', '1', '1', '1' },
//            { '1', ' ', '$', '1', ' ', ' ', ' ', '1' },
//            { '1', ' ', '1', '1', ' ', '1', '1', '1' },
//            { '1', '$', ' ', ' ', ' ', ' ', ' ', '1' },
//            { '1', ' ', '1', '1', '1', '1', '$', '1' },
//            { '1', '$', ' ', ' ', '$', '1', ' ', ' ' },
//            { '1', ' ', '1', '1', ' ', '1', ' ', '1' },
//            { '1', '1', '1', '1', '1', '1', '1', '1' }
//        };

//        // Начальная позиция 'O'
//        int posX = 1;
//        int posY = 1;
//        maze[posY, posX] = 'O';

//        // Целевая позиция (выход из лабиринта)
//        int exitX = maze.GetLength(1) - 1; // Предположим, что выход находится на последнем столбце
//        int exitY = maze.GetLength(0) - 3; // и предпоследней строке

//        int treasuresCollected = 0;

//        while (true)
//        {
//            // Выводим лабиринт и счет сокровищ
//            PrintMaze(maze);
//            Console.WriteLine($"Собранные сокровища: {treasuresCollected}");

//            // Проверка на достижение выхода
//            if (posX == exitX && posY == exitY)
//            {
//                Console.WriteLine("Поздравляю! Вы нашли выход");
//                Console.WriteLine($"Общее количество собранных сокровищ: {treasuresCollected}");
//                break;
//            }

//            // Ввод пользователя
//            Console.Write("Введите направление (w/a/s/ d - вверх/влево/ вниз/вправо, q - выход).: ");
//            char direction = Console.ReadKey().KeyChar;
//            Console.WriteLine();

//            // Выход из программы
//            if (direction == 'q') break;

//            // Перемещение
//            Move(ref posY, ref posX, direction, maze, ref treasuresCollected);
//        }
//    }

//    static void PrintMaze(char[,] maze)
//    {
//        Console.Clear();
//        for (int y = 0; y < maze.GetLength(0); y++)
//        {
//            for (int x = 0; x < maze.GetLength(1); x++)
//            {
//                Console.Write(maze[y, x]);
//            }
//            Console.WriteLine();
//        }
//    }

//    static void Move(ref int posY, ref int posX, char direction, char[,] maze, ref int treasuresCollected)
//    {
//        // Очистка текущей позиции
//        maze[posY, posX] = ' ';

//        // Определение новой позиции
//        int newY = posY;
//        int newX = posX;

//        switch (direction)
//        {
//            case 'w': // вверх
//                newY--;
//                break;
//            case 's': // вниз
//                newY++;
//                break;
//            case 'a': // влево
//                newX--;
//                break;
//            case 'd': // вправо
//                newX++;
//                break;
//            default:
//                Console.WriteLine("Неверное направление. Используйте \"w\", \"a\", \"s\", \"d\" или \"q\".");
//                // Вернуться без обновления позиции
//                maze[posY, posX] = 'O'; // Восстановить предыдущую позицию
//                return;
//        }

//        // Проверка границ и стен
//        if (newY >= 0 && newY < maze.GetLength(0) && newX >= 0 && newX < maze.GetLength(1))
//        {
//            if (maze[newY, newX] == ' ')
//            {
//                posY = newY;
//                posX = newX;
//            }
//            else if (maze[newY, newX] == '$')
//            {
//                posY = newY;
//                posX = newX;
//                treasuresCollected++;
//            }
//        }

//        // Установка нового положения
//        maze[posY, posX] = 'O';
//    }
//}