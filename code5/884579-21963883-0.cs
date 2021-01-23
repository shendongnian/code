    using System.IO;
    using System;
    class Program
    {
        static void Main()
        {
            // Read in every line in the file.
            for (int row = 0; row < 6; row++)
            {
                    // Counting backwards here!
                for (int spaces = 6 - row; spaces > 0; spaces--)
                {
                    Console.Write(" ");
                }
    
                for (int column = 0; column < (2 * row + 1); column++)
                {
                    Console.Write("#");
    
                }
    
                 Console.WriteLine();
             }
             Console.Read();
        }
    }
