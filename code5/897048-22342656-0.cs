        static void ComapreListAndHashSet()
        {
            bool found = false;
            var length = 10000000;
            const int searchValue = -1;
    
            for (int size = 0; size < 15; size++)
            {
                var list = Enumerable.Range(1, size).ToList();
                var hashSet = new HashSet<int>(list);
    
                var timeForList = new Stopwatch();
                timeForList.Start();
                for (int i = 0; i < length; i++)
                {
                    found = found & (list.Contains(searchValue));
                }
                timeForList.Stop();
    
                var timeForHash = new Stopwatch();
                timeForHash.Start();
                for (int i = 0; i < length; i++)
                {
                    found = found & hashSet.Contains(searchValue);
                }
                timeForHash.Stop();
                Console.WriteLine("{0},\t{1},\t{2}", hashSet.Count,
                    timeForList.ElapsedMilliseconds, timeForHash.ElapsedMilliseconds);
            }
        }
