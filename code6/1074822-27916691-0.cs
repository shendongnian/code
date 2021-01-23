    class Triangle
    {
        static void Main(string[] args)
        {
                    int size;
                    Console.Write("Enter the Size:");
                    size = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = size ; j > i; j--)
                        {
                            Console.Write(" ");
                        }
                     
                        for (int x = 1; x <= i; x++)
                        {
                            Console.Write(x);
                        }
                        for (int j = i-1; j > 0; j--)
                        {
                            Console.Write(j);
                        }
                        Console.WriteLine();
                    }
                       Console.ReadKey();
            }
    }
