            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            bool isMyComputerOn = true;
            int cursorCol = Console.CursorLeft;
            int cursorRow = Console.CursorTop;
            while (isMyComputerOn)
            {
                Console.SetCursorPosition(cursorCol, cursorRow);
                Console.WriteLine("Time :  " + chrono.Elapsed);
            }
