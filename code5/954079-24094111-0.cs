             int inputNumber = 0;
               for (; ; )
            {
                Console.WriteLine("Give a number to select a colour between 0-15? ");
                ConsoleColor renk;
    
                if(int.TryParse(Console.ReadLine(),out inputNumber) && (inputNumber>=1 && inputNumber<=15))
                {
                    renk = (ConsoleColor)Convert.ToInt32(inputNumber);
                    Console.BackgroundColor = renk;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No Input Received! Quitting!");
                    break;
                }
            }
