    int m, n; //This is where you tell the PC you want a number and store the var// 
            Console.WriteLine("Enter the number of rows (must be >1) you want in the MATRIX:"); //This writes to the screen//
            m = Convert.ToInt32(Console.ReadLine()); //This converts the input to a number//
            Console.WriteLine("Enter the number of columns (must be >1) you want in the MATRIX:");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[m, n];
            Console.WriteLine("Enter the numbers for the first MATRIX:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("The first MATRIX is:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int[,] b = new int[m, n];
            Console.WriteLine("Enter the numbers for the second MATRIX:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("The second MATRIX is:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(b[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("The MATRIX multiplication is:");
            double[,] c = new double[m, n];
            // A basic matrix multiplication. 
            // Parallelize the outer loop to partition the source array by rows.
            Parallel.For(0, m, i =>
            {
                for (int j = 0; j < n; j++)
                {
                    // Use a temporary to improve parallel performance. 
                    double temp = 0;
                    for (int k = 0; k < n; k++)
                    {
                        temp += a[i, k] * b[k, j];
                    }
                    c[i, j] = temp;
                }
            }); // Parallel.For
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(c[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
