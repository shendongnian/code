    void Main()
    {
        var obj = new Dictionary<string, object>();
        obj["propName1"] = "name";
        obj["propName2"] = 24;
    
        Debug.WriteLine("propName1=" + obj["propName1"]);
        Debug.WriteLine("propName2=" + obj["propName2"]);
    }
