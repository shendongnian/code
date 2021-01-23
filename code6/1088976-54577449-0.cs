        static void Main()
        {
            int width = 0, height = 0;
            width = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    if ((i == 1 || i == height || j == 1 || j == width))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
