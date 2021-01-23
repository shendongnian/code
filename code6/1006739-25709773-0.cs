    private Dictionary<int, string> Data;
    
    public string GetValue(MyAppSettingsEnum key) 
    {
        string value;
        if (this.Data.TryGetValue((int)key, out value))
        {
            return value;
        }
        ...
    }
