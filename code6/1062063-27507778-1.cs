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
            static int Height = 5; //define the height of the square in characters
    
            static void Main(string[] args)
            {
                for (int row = 0; row <= Height; row++) //Each iteration here is one row.
                {
                    //loop representing columns. This is NESTED within the rows so 
                    //that each row prints more than one column
                    for (int column = 0; column <= Width; column++)
                    {
                        if (IsCentreOfSquare(row, column)) //calculate if the current row and column coordinates are the interior of the square
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
                Console.ReadLine(); //pause so that the user can admire the pretty picture.
            }
    
            /// <summary>
            /// Calculates if the row and column indexes specified are in the interior of the square pattern
            /// </summary>
            /// <returns></returns>
            private static bool IsCentreOfSquare(int row, int col)
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
