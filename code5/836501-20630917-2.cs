    DateTime From = DateTime.Now.AddHours(-24);
    DateTime To = DateTime.Now;
    var ScanSize = 5*1024*1024;
    var list = new List<string>();
    DiscoverDirs(@"C:\", list, 
        file => file.LastWriteTime >= From & file.LastWriteTime <= To && file.Length >= ScanSize);
    foreach (string name in list)
    {
        FileInfo file = new FileInfo(name);
        string fullname = file.FullName;
        Console.WriteLine(file.FullName + " ; " + "last changed at  " + " ; " + file.LastWriteTime.ToString());
    }
