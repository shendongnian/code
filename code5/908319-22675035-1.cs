    public void Process(int[] ids)
    {
        var tasks = new List<Task<Tuple<int, bool>>>(ids.Count());
        foreach (int id in ids)
        {
            //The task will run at an indeterminate time so create a copy of id as it may have a new value assigned before that occurs 
            int i = id;
            var task = Task.Factory.StartNew(() => DoWork(i));
            tasks.Add(task);
        }
        foreach (var t in tasks)
        {
            try
            {
                Tuple<int, bool> result = t.Result;
                Console.WriteLine(string.Format("{0} - success = {1}", result.Item1, result.Item2));
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }
            }
        }
    }
