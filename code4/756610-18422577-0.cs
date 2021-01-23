    string rawdata = @"24 august 2013 г.,,14:00,00:00,;
    24 august 2013 г.,,14:00,00:00,;
    24 august 2013 г.,2342,14:00,00:00,23424;
    24 august 2013 г.,2342,14:00,19:00,23424;";//consider this is raw file
    
    string[] lines = rawdata.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    List<string> result = new List<string>();
    foreach (var line in lines)
    {
        if (!line.Contains("24 august 2013 г.,2342"))
        {
            result.Add(line);
        }
    }
