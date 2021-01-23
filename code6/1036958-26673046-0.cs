    using (var reader = new System.IO.StreamReader(dir))
    {
        reader.ReadLine(); // skip first
        string line;
        while ((line = reader.ReadLine()) != null)
        {
        }
    }
