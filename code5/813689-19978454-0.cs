    using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"Experiment/main.txt", true))
    {
             DirectoryInfo dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory+"Experiment/main.txt");
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
         file.WriteLine(DateTime.UtcNow.ToString() + " test");
    }
