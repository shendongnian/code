    Dictionary<string, Dictionary<string,string>> Groups = new...
    string currentGroupName;
    foreach (string line in File.ReadAllLines(iniFile))
    {
        if (lineStartsWith("[") && line.EndsWith("]"))
        {
            currentGroupName = line.Substring(1, line.Length-2);
            Groups.Add(currentGroupName, new Dictionary<string,string>());
        }
        else if (line.Contains("="))
        {
            string[] keyValue = line.Split("=");
            Groups[currentGroupName].Add(keyValue[0], keyValue[1]);
        }
        
    }
