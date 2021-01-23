    StringBuilder Jsonstring = new StringBuilder;
    using (StreamReader sr = System.IO.File.OpenText(filepath))
    {
        while (!sr.EndOfStream))
        {
            Jsonstring.AppendLine(sr.ReadLine());
        }
    }
