    using (var fs = File.Create(dir))
    {
        using (var reader = new StreamReader(fs))
        {
            while ((line = reader.ReadLine()) != null)
            { /* do something */}
        }
    }
