    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                main();
            }
    
            public static ConsoleKeyInfo keyPressed;
    
            private static void main()
            {
            start:
                keyPressed = Console.ReadKey();
    
                while (true)
                {
                loopstart:
    
                    if (keyPressed.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("You pressed the Enter Key!");
                        keyPressed = new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false);
                        goto loopstart;
                    }
                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("You pressed the Escape Key!");
                        goto loopstart;
                    }
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("You pressed the Spacebar!");
                        goto loopstart;
                    }
                    else
                    {
                        break;
                    }
                }
    
                Console.WriteLine("You broke the loop!");
                goto start;
            }
        }
    }
