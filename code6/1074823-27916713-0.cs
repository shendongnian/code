       static void Main(string[] args)
            {
                int i, j, k, odd = 1, size, s = 0;
                Console.Write("Enter the Size:");
                size = Convert.ToInt32(Console.ReadLine());
                int nofSpaces = size - 1;
                for (i = 1; i <= size; i++)
                {
                    for (k = 1; k <= nofSpaces; k++)
                    {
                        Console.Write(" ");
                    }
                    s = 0;
                    for (j = 1; j <= odd; j++)
                    {
                        if (i >= j)
                        {
                            s = s + 1;
                        }
                        else
                        {
                            s = s - 1;
                        }
    
                        Console.Write(s);
                    }
                    Console.Write("\n");
                    odd = odd + 2;
                    nofSpaces = nofSpaces - 1;
                }
                Console.ReadKey();
            }
