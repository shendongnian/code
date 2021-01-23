    private void button1_Click(object sender, EventArgs e)
    {
        Progress<int> progress = new Progress<int>(
            percent => progressbar1.Value = percent);
        DoStuff(progress);
    }
    private void DoStuff(IProgress<int> progress)
    {
        Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                progress.Report(i);
                Thread.Sleep(200); //placeholder for real work
            }
        });
    }
