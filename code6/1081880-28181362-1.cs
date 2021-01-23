    List<WorkItem> list = new List<WorkItem>();
    Task.Run(() =>
        {
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                WorkItem item = new WorkItem();
                switch (rand.Next(0, 3))
                {
                    case 0: item.Category = CategoryOfWorkItem.A; break;
                    case 1: item.Category = CategoryOfWorkItem.B; break;
                    case 2: item.Category = CategoryOfWorkItem.C; break;
                }
                lock (list)
                {
                    item.AddTo(list);
                }
                Task.Delay(rand.Next(100, 1000)).Wait();
                Console.WriteLine("Put {0}", item.Category);
            }
            Console.WriteLine("Putting finished.");
        });
    Task.WaitAll(Task.Run(() =>
        {
            Random rand = new Random();
            while (true)
            {
                WorkItem item;
                Task.Delay(rand.Next(500, 1000)).Wait();
                lock (list)
                {
                    if (list.Count < 1) break;
                    item = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                }
                Console.WriteLine("Get {0}", item.Category);
            }
            Console.WriteLine("Getting finished.");
        }));
