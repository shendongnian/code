    var lines = new HashSet<string>(context.MyEntity.Select(o => o.Property));
    using (StreamReader sr = new StreamReader(theStream))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            if (lines.Add(line))
            {
                //add line
            }
        }
    }
