    using (FileStream fs = new FileStream(path, FileMode.Open))
    {
        fs.Seek(start, SeekOrigin.Begin);
        TextReader tr = new StreamReader(fs);
        string line = tr.ReadLine();
    }
