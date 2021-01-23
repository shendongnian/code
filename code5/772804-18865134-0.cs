    public string GetNum(string val)
    {
        string res = ""; // Assign it an empty string. 
        var numToRom = new Dictionary<string, string>
                           {
                               {"1","I"},
                               {"2","II"}
                               //so on
                           };
            numToRom.TryGetValue(val, out res);
            return res;
    }
