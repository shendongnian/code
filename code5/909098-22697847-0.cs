    Dictionary<string, int> dictKeys = new Dictionary<string, int>();
    Dictionary<int, int> dictValues = new Dictionary<int, int>();
    using (var r = new StreamReader("text1.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            var splitLine = line.Split(',');
            dictKeys.Add(splitLine[0], Convert.ToInt32(splitLine[1]));
        }
    }
    using (var r = new StreamReader("text2.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            var splitLine = line.Split(',');
            dictValues.Add(Convert.ToInt32(splitLine[0]), Convert.ToInt32(splitLine[1]));
        }
    }
    Dictionary<string, int> dictCombined = new Dictionary<string, int>();
    foreach (var item in dictKeys)
    {
        var keyVal = item.Value;
        if (dictValues.ContainsKey(keyVal))
            dictCombined.Add(item.Key, dictValues[keyVal].Value);
    }
    using (var w = File.OpenWrite("Final.txt"))
    {
        foreach (var item in dictCombined)
            w.WriteLine("{0}={1}", item.Key, item.Value);
    }
