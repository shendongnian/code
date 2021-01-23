    class Triangle
        {
            static void Main(string[] args)
            {
                int i,j,k,odd=1,size;
                Console.Write("Enter the Size:");
                size = Convert.ToInt32(Console.ReadLine());
                int nofSpaces=size-1;
                int s = 0;
                for (i = 1; i <= size; i++)
                {
                   int g = 0;
                    for (k = 1; k <= nofSpaces; k++)
                    {
                        Console.Write(" ");
                    }
                    for (j = 1; j <= odd; j++)
                   {
                        
                       if (i >= j)
                       {
                           Console.Write(j);
                           g = j;
                       }
                       else
                       {
                           //for (int n = j-1; n >= i; n--)
                           //{
                           //    Console.Write(n - 1);
                           //}
                           Console.Write(--g);
                       }
                       
                    }
                    Console.Write("\n");
                    odd = odd + 2;
                    nofSpaces = nofSpaces - 1;
                }
                Console.ReadKey();
            }
        }
    }
