    Dictionary<string,string> map;
    
    private string GetEnumName(Enum _enum)
    {
        return string.Format("{0}.{1}", _enum.GetType().Name, _enum.ToString());
    }
            
    void RegisterMapping(Enum @enum, string displayName)
    {
        var enumName= GetEnumName(@enum);
        map.Add(enumName, displayName);
    }
