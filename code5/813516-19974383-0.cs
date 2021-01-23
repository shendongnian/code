    while (line != null)
    {
        if (System.IO.Path.GetExtension(line) == "txt")
        {
            result.Append(line);
            result.Append("\n");
            line = reader.ReadLine();
        }
    }
