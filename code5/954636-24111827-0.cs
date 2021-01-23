        static void Main(string[] args)
        {
            long totalListSortTime = 0;
            long totalCustomSortTime = 0;
            for (int c = 0; c < 100; c++)
            {
                List<string> list1 = new List<string>();
                List<string> list2 = new List<string>();
                for (int i = 0; i < 5000; i++)
                {
                    var rando = RandomString(15);
                    list1.Add(rando);
                    list2.Add(rando);
                }
                Stopwatch watch1 = new Stopwatch();
                Stopwatch watch2 = new Stopwatch();
                watch2.Start();
                list2 = Sort(list2);
                watch2.Stop();
                totalCustomSortTime += watch2.ElapsedMilliseconds;
                watch1.Start();
                list1.Sort();
                watch1.Stop();
                totalListSortTime += watch1.ElapsedMilliseconds;
 
                
            }
            Console.WriteLine("totalListSortTime = " + totalListSortTime);
            Console.WriteLine("totalCustomSortTime = " + totalCustomSortTime);
            Console.ReadLine();
        }
