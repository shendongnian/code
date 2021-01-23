    foreach (string line in File.ReadLines(filePath))
    {
       if (line.StartsWith("google"))
       {
            writer.WriteLine(line + "StackOverflow");
       }
       else
       {
            writer.WriteLine(line);          
       }
    }
