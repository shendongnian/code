    string line;
    using (StreamReader StreamReader1 = new StreamReader(sFileName))
    {
        while ((line = StreamReader1.ReadLine()) != null)
        {
            if (!string.IsNullOrEmpty(line.Trim()))
                sb.AppendLine(line);
            // ...
        }
    }
