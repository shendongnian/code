    var lines = new List<string>();
    string outputPath = // your output path here
    using (var file = new System.IO.StreamReader("c:\\mycsv.csv")) 
    {
      string line;
      while ((line = file.ReadLine()) != null)
      {
        if (!line.StartsWith("#"))
        {
          lines.Add(line);
        }
      } 
    }
    File.WriteAllLines(outputPath, lines);
