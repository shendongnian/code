    private Dictionary<String, Int32> ProcessInputString(string str) { 
        var Dictionary = new Dictionary<String, Int32>();
        var Entries = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach(var Entry in Entries) {
            var EntryData = Entry.Split('=', StringSplitOptions.RemoveEmptyEntries);
            var Key = EntryData[0];
            var Value = Convert.ToInt32(EntryData[1]);
            if(!Dictionary.ContainsKey(Key))
                Dicationary[Key] = Value;
        }
        return Dictionary;
    }
