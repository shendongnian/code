    var lines = new List<string>();
    int counter = 0;
    string line;
    using (var reader = new StreamReader("filePath"))
    {
       while ((line = reader.ReadLine()) != null)
       {
              lines.Add(line);
              counter++;
              if (counter == 120000)
              {
                  File.WriteAllLines("filePath",lines);
                  lines.Clear();
                  counter = 0;
              }
        }
    }
    if(lines.Count > 0) File.WriteAllLines("path", lines);
