            int j = 0;
            Parallel.ForEach(Enumerable.Range(0, 5), i =>
            {
                lock (SomeLockObject)
                {
                    Console.WriteLine(j++);
                }
                GetTotal();
            }
