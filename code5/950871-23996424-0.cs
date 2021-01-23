    string[] lines = File.ReadAllLines("decimal list.txt");
    List<doulbe> values = new List<double>();
    
    foreach(string line in lines)
    {
        double value;
        
        if (double.TryParse(line, out value))
        {
            values.Add(value);
        }
    }
