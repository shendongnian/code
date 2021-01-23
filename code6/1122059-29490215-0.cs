    public void CountMacNames(String macName)
    {
        string path = @"D:\Counter\macNameCounter.csv";
    
        // Read all lines, but only if file exists
        string[] lines = new string[0];
        if (File.Exists(path))
            lines = File.ReadAllLines(path);
    
        // This is the new CSV file
        StringBuilder newLines = new StringBuilder();
        bool macAdded = false;
    
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && parts[0].Equals(macName))
            {
                int newCounter = Convert.ToIn32(parts[1])++;
                newLines.AppendLine(String.Format("{0},{1}", macName, newCounter));
                macAdded = true;
            }
            else
            {
                newLines.AppendLine(line.Trim());
            }
        }
     
        if (!macAdded)
        {
            newLines.AppendLine(String.Format("{0},{1}", macName, 1));
        }
    
        File.WriteAllText(path, newLines.ToString());
    }
