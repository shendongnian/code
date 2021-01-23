    public async Task Update()
    {
        while (true)
        {
            db.InsertCurrentTime(DateTime.Now);
            await Task.Delay(TimeSpan.FromSeconds(5))
                .ConfigureAwait(false);//remove if you want the UI context
        }
    }
