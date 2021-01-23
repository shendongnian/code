    while(Reader.Read() != null)
    {
        ApplicationPort.WriteLine(line);
        var endDate = DateTime.Now + TimeSpan.FromSeconds(1.5);
        while (DateTime.Now() < endDate)
        {
            Application.DoEvents();
        }
    }
