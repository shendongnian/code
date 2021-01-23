    public void Update(GameTime gameTime)
    {
        Task[] tasks = new Task[engineComponents.Count];
        for (int i = 0; i < tasks.Length; i++)
        {
            int inner = i; // Declare another temp variable
            tasks[i] = new Task(() => engineComponents[inner].Update(gameTime));
            tasks[i].Start();
        }
        Task.WaitAll(tasks);
    }
