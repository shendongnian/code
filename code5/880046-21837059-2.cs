    var lines = new List<string>();
    int counter = 0,i = 1;
    string line;
    using (var reader = new StreamReader("filePath"))
    {
       while ((line = reader.ReadLine()) != null)
       {
              lines.Add(line);
              counter++;
              if (counter == 120000)
              {
                  string fileName = String.Format("file{0}.txt",i);
                  File.WriteAllLines(fileName,lines);
                  lines.Clear();
                  counter = 0;
                  i++;
              }
        }
    }
    if(lines.Count > 0) File.WriteAllLines("path", lines);
