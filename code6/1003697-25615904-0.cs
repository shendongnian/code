    const int COUNT = 100000;
            HashSet<int> hashSetOfInts = new HashSet<int>();
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < COUNT; i++)
            {
                hashSetOfInts.Add(i);
            }
            stopWatch.Start();
            for (int i = 0; i < COUNT; i++)
            {
                hashSetOfInts.Contains(i);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
            List<int> listOfInts = new List<int>();
            for (int i = 0; i < COUNT; i++)
            {
                listOfInts.Add(i);
            }
            stopWatch.Start();
            for (int i = 0; i < COUNT; i++)
            {
                listOfInts.Contains(i);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            Console.Read();
