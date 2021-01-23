        string path = @"d:\temp\testFile.txt";
        if (File.Exists(path))
        {
             string[] loadedLines = File.ReadAllLines(path);
             if(loadedLines.Length >= 5)
             {
                  string line5 = loadedLines[4];
                  if(line5.Length >= 10)
                  {
                      string key = line5.Substring(0,5);
                      string value = line5.Substring(5,5);
                      .....
                  }
             }
        }
