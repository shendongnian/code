    List<string> stringList = new List<string>
    {
        "ABC",
        "DEF",
        "GHI",
        "GHI",
    };
    
    List<double> doubleList = new List<double>
    {
        1d,
        2,
    
    };
    
    List<string> combined = new List<string>();
    int count = stringList.Count >= doubleList.Count ? stringList.Count : doubleList.Count;
    for (int i = 0; i < count; i++)
    {
        combined.Add(string.Format("{0},{1}", stringList.Count <= i ? "" : stringList[i]
                                            , doubleList.Count <= i ? "" : doubleList[i].ToString()));
    }
    
    File.WriteAllLines("yourFilePath.csv", combined);
