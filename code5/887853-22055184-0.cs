    Dictionary<int,String> mapDictionary;
    string[] mapNames = rawData.Split(splitChar, StringSplitOptions.None);
    foreach(String str in mapNames)
    {
        {
        String mapid = str.Substring(str.IndexOf(":"));
        String mapname = str.Remove(0, str.IndexOf(':') + 1);
        mapDictionary.Add(Convert.ToInt32(mapid), mapname);
        }
    }
