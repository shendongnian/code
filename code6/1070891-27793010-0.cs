    static void Main(string[] args)
        {
            Console.WriteLine("start");
            bool xa = true;
            int switchNum = 48; // ASCII for '0' Key
            int switchNumBkup = switchNum; // to restore switchNum on ivalid key
            while (xa == true)
            {    
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switchNumBkup = switchNum; // to restore switchNum on ivalid key
                    switchNum = key.KeyChar; // Get the ASCII of keyPressed
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Esc Key was pressed. Exiting now....");
                        Console.ReadKey(); // TO Pause before exiting
                        break;
                    }
                }
                switch (switchNum)
                {
                        case 48: //ASCII for 0
                            Console.WriteLine("Text");
                            break;
                        case 49: //ASCII for 1
                            Console.WriteLine("Stuff");
                            break;
                        case 50: //ASCII for 2
                            Console.WriteLine("More Stuff");
                            break;
                        default :
                            Console.WriteLine("Invalid Key. Press Esc to exit.");
                            switchNum = switchNumBkup;
                            break;
                }                
                System.Threading.Thread.Sleep(200) ;                
            }
            Console.WriteLine("Exiting ");
        }
