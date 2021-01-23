    static void Main(string[] args)
            {
                Console.WriteLine("Enter the number:");
                int n = int.Parse(Console.ReadLine());
                int zero = 0;
                long fac=1;
                for (int i = 1; i <= n; i++)
                {
                    fac *= i;
                }
                Console.WriteLine("Factorial is:" + fac);
            ab:
               
              
            if (fac % 10 == 0)
            {
                fac = fac / 10;
                zero++;
                goto ab;
            }
            else
            {
                Console.WriteLine("Zeros are:" + zero);
            }
            Console.ReadLine();
            }
