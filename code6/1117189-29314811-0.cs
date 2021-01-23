    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int NUM_ROWS = 10;
                const int NUM_COLS = 2;
    
                int[,] randint = new int[NUM_ROWS, NUM_COLS];
                Random randNum = new Random();
    
                for (int row = 0; row < randint.GetLength(0); row++)
                {
                    randint[row, 0] = randNum.Next(1, 100);
                    randint[row, 1] = randint[row, 0] * randint[row, 0];
    
                    Console.Write(string.Format("{0,5:d} {1,5:d}\n", randint[row, 0], randint[row, 1]));
    
                    MessageBox.Show(string.Format("{0,5:d} {1,5:d}\n", randint[row, 0], randint[row, 1]));
                    Console.ReadKey();
                }
            }
        }
    }
