    public string GetServerTime(IProgress<int> prog)
    {
        for (int i = 0; i < 10; i++)
        {
            prog.Report(i * 10);
            System.Threading.Thread.Sleep(200);
        }
        return DateTime.Now.ToString();
    }
