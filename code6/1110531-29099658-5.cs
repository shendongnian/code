    StringBuilder jsonString = new StringBuilder;
    using (StreamReader sr = System.IO.File.OpenText(filepath))
    {
        while (!sr.EndOfStream))
        {
            jsonString.AppendLine(sr.ReadLine());
        }
    }
