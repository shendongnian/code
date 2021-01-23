    static void Main(string[] args)
            {
                // Get the number of rows
                Console.WriteLine("Enter the number of rows:");
                int arrayRows = Convert.ToInt32(Console.ReadLine());
    
                // Get the number of columns
                Console.WriteLine("Enter the number of columns:");
                int arrayCols = Convert.ToInt32(Console.ReadLine());
    
                // For each item in the row
                for (int i = 0; i < arrayRows; i++)
                {
                    // For each item in the column
                    for (int j = 0; j < arrayCols; j++)
                    {
                        // Show a star
                        Console.Write("*");
                    }
    
                    // End the line
                    Console.WriteLine(""); 
                }
    
                // Read the line to stop the app from closing
                Console.ReadLine();
            }
