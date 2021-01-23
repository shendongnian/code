    class Class1
    {
        public Form1 f { get; set; }
        public void Process(BackgroundWorker bg)
        {
            for (int i = 1; i <= 100; i++)
            {
                f.AddListBoxItem("Test");
                Thread.Sleep(100);
                bg.WorkerReportsProgress = true;
                bg.ReportProgress(i);
            }
        }
    }
