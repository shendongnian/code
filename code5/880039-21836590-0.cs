    var lines = File.ReadAllLines("path");
    foreach(var line in lines)
    {
        if(line.Contains(" />")) line = line.Replace(" />","/>");
    }
    File.WriteAllLines("path", lines);
