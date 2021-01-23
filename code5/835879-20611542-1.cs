    Dictionary<string, List<int>> myDict = new Dictionary<string, List<int>>();
    public void AddNumber(string key, int value)
    {
         List<int> list;
         if(!myDict.TryGetValue(key, out list))
         {
             list = new List<int>();
             myDict.Add(key, list);
         }
         list.Add(value);
    }
