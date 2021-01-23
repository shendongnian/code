    private Task ProcessItemsAsync()
    {
        for (int i = 0, n = items.Count; i < n; i++)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            batch.Add(items[i]);
            if (batch.Count == 3 || i >= items.Count - 3)
            {
                List<Task> tasks = new List<Task>(3);
                foreach (Item item in batch)
                    tasks.Add(Task.Run(() => ProcessItem(item)));
                await Task.WhenAll(tasks.ToArray());
                batch.Clear();
            }
            stopwatch.Stop();
            int elapsed = (int)stopwatch.ElapsedMilliseconds;
            int delay = (3000) - elapsed;
            if (delay > 0)
                await Task.Delay(delay);
        }
    }
