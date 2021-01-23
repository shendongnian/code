    using (StreamReader sr = new StreamReader(fi.FullName))
    {
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            sb.AppendLine(line);
        }
    }
