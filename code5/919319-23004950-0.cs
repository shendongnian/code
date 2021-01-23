     static Random rand; 
                static void Main(string[] args)
                {
                    int[,] A = new int[5, 7];
                  rand = new Random();
        
                  SumOdd(ref A);                 
                    
                  
                    Console.ReadLine();
                }
        
                private static void SumOdd(ref int[,] array)
                {
                    int sum = 0;
                    int rows = array.GetLength(0);
                    int cols = array.GetLength(1);
        
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            array[i, j] = rand.Next(-100, 100);
                            if (array[i,j] % 2 != 0)
                            {
                                Console.WriteLine(array[i, j]);
                                sum += array[i, j];
                            }
                            Console.WriteLine(array[i, j] + " ");
                        }
                    }
                   Console.WriteLine("The Sum of all Odd is: " + sum.ToString());
                }
                
