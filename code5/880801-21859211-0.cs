        List<string> lines = File.ReadAllLines(@"C:\filepath.txt");
        List<string> newlines = new List<string>();
        foreach(string line in lines)
        {
          string[] temp = line.Split('|');
          newlines.Add(temp[0] + "|" + temp[1] + "|" + "1");
        }
    
     File.WriteAllLines(@"C:\filepath.txt", newlines)
