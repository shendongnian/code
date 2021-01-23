    private void button1_Click(object sender, EventArgs e)
    {
        var worker = new BackgroundWorker();
        worker.DoWork += ComputeResult;
        worker.RunWorkerCompleted += (s, args) =>
        {
            DoStuffWithResult(args.Result);
        };
        worker.RunWorkerAsync();
    }
