    IEnumerable<string> keys = lookupTable.Select(t => t.Key);
    foreach(string key in keys)
    {
        // use the value of key to access the IEnumerable<List<CustomObject>> from the ILookup
        foreach( List<CustomObject> customList in lookupTable[key]
        {
            Console.WriteLine(customList);
        }        
    }
