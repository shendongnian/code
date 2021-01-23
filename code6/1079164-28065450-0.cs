        Task<int>[] tasks = new Task<int>[n];
        for (int i = 0; i < n; i++)
        {
            tasks[i] = Task<int>.Factory.StartNew(action, i);
        }
