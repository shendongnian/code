            Parallel.ForEach(Enumerable.Range(0, 5), i =>
            {
                int tempj;
                lock (SomeLockObject)
                {
                    tempj = j++;
                }
                Console.WriteLine(tempj-1);
                GetTotal(tempj);
            });
