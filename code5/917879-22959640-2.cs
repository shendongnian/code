    using (var fs = File.Open(dir, FileMode.OpenOrCreate))
    {
        using (var reader = new StreamReader(fs))
        {
            while ((line = reader.ReadLine()) != null)
            { /* do something */}
        }
    }
