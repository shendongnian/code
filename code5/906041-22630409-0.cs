        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Globalization;
        using System.Threading;
        using System.Diagnostics;
        class Game
        {
        static void Main()
        {
            bool isTrue = true;
            while (isTrue == true)
            {
            Console.BufferHeight = 25;
            Console.BufferWidth = 80;
            Console.CursorVisible = false;
            Random rnd = new Random();
            int row = rnd.Next(1, 80);
            int col = rnd.Next(1, 25);
            int numbers = rnd.Next(0,9);
            int chars = rnd.Next(0, 25);
            string lettersAndChars = "";
            Console.SetCursorPosition(row, col);
            int choose = rnd.Next(1,3);
            while (choose == 1)
            {        
                lettersAndChars += (int)(numbers); 
                break;
            }
            while (choose == 2)
            {
                lettersAndChars += (char)(chars + 'A');
                break;
            }
            lettersAndChars = lettersAndChars.ToUpper();
            Console.WriteLine(lettersAndChars);
            DateTime endTime = DateTime.Now.AddSeconds(2);      
            while (!Console.KeyAvailable && DateTime.Now < endTime)
                Thread.Sleep(1);
            if (Console.KeyAvailable)
            {
                var keyPress = Console.ReadKey();
                string keyPressString = keyPress.KeyChar.ToString();
                keyPressString = keyPressString.ToUpper();
                if (keyPressString == lettersAndChars)
                {
                    Console.Clear();
                    continue;
                }
            }
            
            Console.Clear();
            int leftOffSet = (Console.WindowWidth / 2) -3;
            int topOffSet = (Console.WindowHeight / 2) -2;
            Console.SetCursorPosition(leftOffSet, topOffSet);
            Console.WriteLine("Game Over");
            leftOffSet = (Console.WindowWidth / 2) - 25;
            topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);
            Console.WriteLine("Press \"R\" to start again or \"ESC\" to exit the game...");
            var resOrExit = Console.ReadKey();
            Console.Clear();
            if ((char)resOrExit.Key == 'R')
            {
                continue;
            }
            else if (resOrExit.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            }
        
        }
        }
