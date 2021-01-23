    private object dictLock = new object();
    private Dictionary<int, int> dict1 = new Dictionary<int, int>();
    private Dictionary<string, int> dict2 = new Dictionary<string, int>();
    
    public void Add(int rownr, int id, string key)
    {
        lock(dictLock)
        {
            dict1.Add(id, rownr);
            dict2.Add(key, rownr);
        }
    }
    
    public int GetRow(int id)
    {
        lock(dictLock)
        {
            return dict1[id];
        }
    }
    
    public int GetRow(string key)
    {
        lock(dictLock)
        {
            return dict2[key];
        }
    }
