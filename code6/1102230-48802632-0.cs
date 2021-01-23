    namespace PurushLogics
    {
        class Purush_PrimeNos
        {
            static void Main()
            {
                //Prime No Program
                bool isPrime = true;
                Console.WriteLine("Enter till which number you would like print Prime Nos\n");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Prime Numbers : ");
                for (int i = 2; i <= n; i++)
                {
                    for (int j = 2; j <= n; j++)
                    {
    
                        if (i != j && i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
    
                    }
                    if (isPrime)
                    {
                        Console.Write("\t" + i);
                    }
                   isPrime = true;
                }
                Console.ReadKey();
            }
        }      
    }
