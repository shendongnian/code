    public async Task AddQueueAsync()
    {
        var jobs = await GetJobsFromQueueAsync();
        MessageBox.Show(jobs.Count().ToString());
    }
