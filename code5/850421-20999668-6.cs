    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleChar
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Title = "Stackoverflow - Super example";
                Console.CursorVisible = false;
    
                int yMax = Console.WindowHeight;
                int xMax = Console.WindowWidth;
                char[,] characters= new char[Console.WindowWidth, Console.WindowHeight];
    
                for (int i = 0; i < Console.WindowWidth; i++ )
                {
                    for (int j = 0; j < Console.WindowHeight; j++)
                    {
                        char currentChar = ' ';
                        
                        if((i == 0) || (i == Console.WindowWidth - 1))
                        {
                            currentChar = '║';
                        }
                        else
                        {
                            if((j == 0) || (j == Console.WindowHeight - 1))
                            {
                                currentChar = '═';
                            }
                        }                    
    
                        characters[i, j] = currentChar;
                    }
                }
                
                characters[0, 0] = '╔';
                characters[Console.WindowWidth-1, 0] = '╗';
                characters[0, Console.WindowHeight - 1] = '╚';
                characters[Console.WindowWidth - 1, Console.WindowHeight - 1] = '╝';
    
                    for (int y = 0; y < yMax ; y++)
                    {
                        string line = string.Empty;
                        for (int x = 0; x < xMax; x++)
                        {
                            line += characters[x, y];
                        }
                        Console.SetCursorPosition(0, y);
                        Console.Write(line);
                    }
                Console.SetCursorPosition(0, 0);
            }
        }
    }
