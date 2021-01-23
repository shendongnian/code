        static void Main(string[] args)
        {
            int rows = 10;
            int columns = 10;
            int[,] matrix = new int[rows, columns];
            Random rnd = new Random();
            Enumerable.Range(0, rows)
                .ToList()
                .ForEach(row => Enumerable.Range(0, columns)
                    .ToList()
                    .ForEach(column => 
                        {
                            matrix[row, column] = rnd.Next(-100, 100);
                            Console.Write(column == columns ? Environment.NewLine + matrix[row, column].ToString() + "\t" : matrix[row, column].ToString() + "\t");
                        }));
            Console.ReadKey();
        }
