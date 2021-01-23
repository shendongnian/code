    using (StreamWriter writer = new StreamWriter(path, false, encoding))
    {
        foreach (string str in contents)
        {
            writer.WriteLine(str.Replace("\r","").Replace("\n",""));
        }
    }
