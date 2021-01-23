    foreach (var path in new [] { @"C:\foo\bar\", @"\\server\bar" })
    {
        var uri = new Uri(path);
        if (uri.IsUnc)
        {
            Console.WriteLine("Connects to host '{0}'", uri.Host);
        }
        else
        {
            Console.WriteLine("Local path");
        }
    }
