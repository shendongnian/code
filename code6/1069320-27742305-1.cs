    private async void button1_Click(object sender, EventArgs e)
    {
        var progress = new Progress<int>(ShowProgressInUi);
        var result = await Task.Run(() => DoParallelWorkAsync(progress));
            
        // Do something with final result
        label1.Text = result;
    }
    private void ShowProgressInUi(int progress)
    {
        label1.Text = string.Format("Progress: {0} % done...", progress);
    }
    private static async Task<string> DoParallelWorkAsync(IProgress<int> progress)
    {
        // This work is done in a separate thread.
        // In this case a background thread (from the thread pool),
        // but could be run on a foreground thread if the work is lengthy.
        for (var i = 1; i <= 10; i++)
        {
            // Simulate workload
            await Task.Delay(100);
            progress.Report(i * 10);
        }
        
        return "All done";
    }
