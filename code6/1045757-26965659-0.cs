    namespace ArrayRandomNumbers
    {
        class RandomNumbers
        {
            public static void Main()
            {
                int[] num = new int[1000];
                Random rnd = new Random();
    
                for (int i = 0; i < 1000; i++)
                {
                    num[i] = rnd.Next(1000);
                    Console.WriteLine(num[i]);
                }
                 Array.Sort(num);
                 num.ToList().ForEach(delegate(int s)
                 {
                     Console.WriteLine(s);
                 });
                Console.ReadLine();       
            }
        }
    } 
