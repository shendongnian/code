    string directory = @"C:\test.csv";
    using(StreamReader stream = new StreamReader(directory, Encoding.ASCII))
    {
        string line = "";
        line = stream.ReadLine();
        string[] column = line.Split(';');
    }
