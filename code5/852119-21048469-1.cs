    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Board
    {
        class Program
        {
            static void Main(string[] args)
            { 
                // Create the board
                Board b = new Board();
                // Print the maze
                Console.Write(b.ToString());
                Console.ReadKey();
            }
        }
    
        class Board
        {
            private BoardItem[,] items = new BoardItem[10, 10];
    
            // Board contructor - populate the multidimensional array - do you own login here to populate the cells.
            public Board()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {                        
                        items[i, j] = new BoardItem();
                    }
                }
            }
    
            // Print each cell from the MineSweeper
            public override string ToString()
            {
                string ret = "";
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        ret += items[i, j].ToString();
                    }
                    ret += Environment.NewLine;
                }
    
                return ret;
            }
        }
    
        class BoardItem
        {
            char BoardItemCharToPriint = '-';
    
            // Print the current cell
            public override string ToString()
            {
                return BoardItemCharToPriint.ToString();
            }
        }
    }
