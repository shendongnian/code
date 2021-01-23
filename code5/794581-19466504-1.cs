    using System;
    using System.Timers;
    namespace Prog4
    {
        class program
        {
            private static int _countDown = 30; // Seconds
            private static bool waySelected = false;
            static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                if (waySelected == false)
                {
                    if (_countDown-- <= 0)
                        Console.WriteLine("You got crushed!");
                    else
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.WriteLine(_countDown + " seconds until you are crushed");
                    }
                }
            }
            static void Main(string[] args)
            {
                Timer aTimer = new Timer(1000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.Enabled = true;
                Random random = new Random();
                int north = random.Next(1, 5);
                int south = random.Next(1, 5);
                int east = random.Next(1, 5);
                int west = random.Next(1, 5);
                Console.WriteLine("You are in a room that is slowly closing in on you, it has only four exits.\n" +
                                  "The four exits face: North, South, East and West. \n" +
                                  "Press n for North, \n" +
                                  "      s for South, \n" +
                                  "      e for East, \n" +
                                  "      w for West, \n" +
                                  "Only one exit leads to outside, the rest lead to certain doooooooooooooom \n");
                Console.WriteLine("Press any key to continue...");
            
                ConsoleKeyInfo way = Console.ReadKey(true);
                waySelected = true;
                Console.Clear();
                switch (way.KeyChar)
                {
                    case 'n':
                        Console.WriteLine("The Next room is looks like North ...");
                        break;
                    case 's':
                        Console.WriteLine("The Next room is looks like South ...");
                        break;
                    case 'e':
                        Console.WriteLine("The Next room is looks like East ...");
                        break;
                    case 'w':
                        Console.WriteLine("The Next room is looks like West ...");
                        break;
                    default:
                        Console.WriteLine("You choose wrong way, you got crushed!");
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }
