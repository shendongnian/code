    while ((line = file.ReadLine()) != null)
    {
      if (!line.StartsWith("#")
      {
        lines.Add(line);
      }
    }
    // lines.RemoveAll(l => l.Contains("#")); DELETE THIS LINE
