    var lines = new List<string>();
    string line;
    using (var file = new System.IO.StreamReader("c:\\mycsv.csv")) 
    {
      while ((line = file.ReadLine()) != null)
      {
        if (!line.StartsWith("#")
        {
          lines.Add(line);
        }
      } 
    }
    File.WriteAllLines(outputPath, lines);
