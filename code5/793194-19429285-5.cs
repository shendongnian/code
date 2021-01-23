    List<string> stringList = new List<string>();
    List<double> doubleList = new List<double>();
    
    List<string> combined = new List<string>();
    if (stringList.Count == doubleList.Count)
    {
        for (int i = 0; i < stringList.Count; i++)
        {
            combined.Add(string.Format("{0},{1}", stringList[i], doubleList[i]));
        }
    
        File.WriteAllLines("yourFilePath.csv", combined);
    }
