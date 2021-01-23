    private async void button1_Click(object sender, EventArgs e)
    {
        // some stuff
        List<Task> tasks = new List<Task>();
        foreach (...)
        {
            tasks.Add(Task.Run(() => ...));
        }
        await Task.WhenAll(tasks);
        // some other stuff
    }
