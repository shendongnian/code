    class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter number : ");
                int num = Convert.ToInt32(Console.ReadLine());
                 int[] factor ;
                for (int i = 1; i <= num; i++) 
                {
                    actor = new int[i];
    
                    if (num % i == 0) 
                    {
                        Console.WriteLine("Number going in i: " + i);
                        factor[i - 1] = i;
                    };
                }
    
    
                //Not working
                for (int i = 0; i < factor.length; i++) 
                {
                    Console.WriteLine(factor[i]);
                }
    
            }
        }
