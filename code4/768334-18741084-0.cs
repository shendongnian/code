    public List<string[]> parseCSV(string path)
    {
             List<string[]> parsedData = new List<string[]>();
    
             using (StreamReader readFile = new StreamReader(path))
             {
                      string line;
                      string[] row;
    
                      while ((line = readFile.ReadLine()) != null)
                      {
    
                               row = line.Split(',');
                               parsedData.Add(row);
                      }
             }
             return parsedData;
    }
