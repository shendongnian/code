           bool test = false;
            do
            {
                try
                {
                    Console.SetCursorPosition(2, 12);
                    Console.Write(" ");
                    Console.SetCursorPosition(2, 12);
                    Num = Convert.ToDecimal(Console.ReadLine());
                    test = false;
                }
                catch
                {
                    test = true;
                }
            } while (test);
            Console.SetCursorPosition(18, 12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            telNumber = Console.ReadLine();
            bool Ptest = false;
            do
            {
                try
                {
                    Console.SetCursorPosition(47, 12);
                    Console.Write(" ");
                    Console.SetCursorPosition(47, 12);
                    Amount = Convert.ToDecimal(Console.ReadLine());
                    Console.SetCursorPosition(65, 12);
                    Amount = Amount * 2;
                    Console.WriteLine("P " + Amount.ToString("0.00"));
                    Console.SetCursorPosition(65, 15);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("P " + Amount.ToString("0.00"));
                    Console.SetCursorPosition(65, 17);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("P " + Amount.ToString("0.00"));
                    Ptest = false;
                }
                catch
                {
                    Ptest = true;
                }
            } while (Ptest);
            //Amount
            Console.ReadLine();
