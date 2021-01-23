    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Stars
    {
        class Program
        {
            static int Width = 5; //define the width of the square in characters
            static int Height = 0; //define the height of the square in characters
    
            static void Main(string[] args)
            {
                for (int i = 0; i <= Height; i++) //loop for rows
                {
                    for (int j = 0; j <= Width; j++) //loop for colums
                    {
                        if (CentreSquare(i, j)) //calculate if the current row and column coordinates are the interior of the square
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine(); //this row is over. move to the next row
                }
                Console.ReadLine();
            }
    
            /// <summary>
            /// Calculates if the row and column indexes specified are in the interior of the square pattern
            /// </summary>
            /// <returns></returns>
            private static bool CentreSquare(int row, int col)
            {
                if (row > 0 && row < Height)
                {
                    if (col > 0 && col < Width)
                    {
                        return true;
                    }
                }
    
                return false;
            }
        }
    }
