    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Sockets;
    
    namespace Battleships
    {
        class ReadWrite
        {
            public void GetUsername()
            {
    
            }
        }
        class Variables
        { // Variables for the game - win, lose, board slots, user names, highscores
            public volatile Dictionary<string, string> BoardPieces = new Dictionary<string, string>(); // board slots like A1, D6 etc.
            private string username;
            private string settingsDirectory;
            private string settingsFile;
            public string _setDir
            {
                get
                {
                    return settingsDirectory;
                }
                set
                {
                    settingsDirectory = value;
                }
            }
            public string _setFile
            {
                get
                {
                    return settingsFile;
                }
                set
                {
                    settingsFile = value;
                }
            }
            public string _user
            {
                get
                {
                    return username;
                }
                set
                {
                    username = value;
                }
            }
        }
        class Game
        {
            private Variables vars = new Variables();
    
            public Variables _vars
            {
                get
                {
                    return vars;
                }
                set
                {
                    vars = value;
                }
            }
    
    
            public void DrawBoard() // Board should be 10x10 (1-10, A-J)
            { // should be A | B | C | D etc.
                //Console.WriteLine("   | A | B | C | D | E | F | G | H ");
                //Console.WriteLine("-----------------------------------");
                //Console.WriteLine(" 1 | {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} ");
                // test code:
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("   | A | B | C | D | E | F | G | H | I | J ");
                        Console.WriteLine("-------------------------------------------");
                    }
                    else
                    { // {0} = 1-10, lines of the board itself
                        Console.WriteLine("I would've written lines 1-10");
                        //Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} ", i);
                        //Console.WriteLine("-------------------------------------------");
                    }
                }
            }
            public void ResetBoard()
            {
                //if (vars.BoardPieces.Count == 0)
                if (true)
                {
                    for (int i = 1; i <= 10; i++) // letters A-J
                    {
                        for (int n = 1; n <= 10; n++)
                        {
                            Console.WriteLine("Processing n = {0}", n);
                            string KeyToAdd = ((char)(i + 64)).ToString() + n;
                            //Console.WriteLine("The character printed is {0}", (char)(i + 65));
                            vars.BoardPieces.Add(KeyToAdd, i.ToString());
                            // Console.WriteLine("Written {0} to BoardPieces[{1}]", i, KeyToAdd);
                            Console.WriteLine("The current value in BoardPieces[{0}] is {1}", KeyToAdd, vars.BoardPieces[KeyToAdd]);
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                Game prog = new Game();
                prog.DrawBoard();
                prog.ResetBoard();
                prog.DrawBoard();
                foreach (KeyValuePair<string, string> keyvalue in prog._vars.BoardPieces)
                {
                    Console.WriteLine("Key: {0}\t Value: {1}", keyvalue.Key, keyvalue.Value);
                }
                if (prog._vars.BoardPieces.Count == 0)
                {
                    Console.WriteLine("No keys found!");
                }
                Console.ReadKey();
            }
        }
    }
