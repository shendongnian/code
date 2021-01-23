            var list = new List<int>(64);
            for (var i = 1; i <= 64; i++)
            {
                list.Add(i);
            }
            var result = Parallel.ForEach(list, entry =>
            {
                var line = string.Format("Thread ID {0} is listing entry {1}", Thread.CurrentThread.ManagedThreadId, entry);
                Console.WriteLine(line);
            });
            while (!result.IsCompleted)
            {
                Thread.Sleep(50);
            }
            Console.ReadKey();
