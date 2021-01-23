    string fname = "a.txt";
    //WRITER
    Task.Factory.StartNew(() =>
    {
        var f = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
        var s = new StreamWriter(f);
        long l = 0;
        while (true)
        {
            s.WriteLine(l++);
            s.Flush();
            Task.Delay(1000).Wait();
        }
    });
    //READER
    Task.Factory.StartNew(() =>
    {
        Task.Delay(1000).Wait();
        var f = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        var s = new StreamReader(f);
        while (true)
        {
            var line = s.ReadLine();
            if (line == null) { Task.Delay(100).Wait(); continue; };
            Console.WriteLine("> " +  line + " <");
        }
    });
