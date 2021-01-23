    namespace ArrayRandomNumbers
    {
        class RandomNumbers
        {
            public static void Main()
            {
                int[] num = new int[1000];
                Random rnd = new Random();
                var randList = new List<int>();
                var distinctList = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    num[i] = rnd.Next(1000);
                    randList.Add(num[i]);
                    Console.WriteLine(randList[i]);
                }
                distinctList = randList.Distinct().ToList();
                distinctList.Sort();
                Console.ReadLine();
                distinctList.ForEach(delegate(int s)
                {
                    Console.WriteLine(s.ToString());
                });
                Console.ReadLine(); 
            }
        }
    } 
