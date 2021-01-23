    var allinone = (from l in MyList
                           join d in SomeDictionary.SelectMany(s => s.Value) on l equals d.Value.ToString()
                           select d).ToList();
    Dictionary<string, Dictionary<string, object>> SomeDictionary = new Dictionary<string, Dictionary<string, object>>();
            List<string> MyList = new List<string>()
        {
            "2","3","4","5"
        };
            Dictionary<string, object> internalDictionary = new Dictionary<string, object>();
            internalDictionary.Add("two", 2);
            internalDictionary.Add("three", 3);
            internalDictionary.Add("four", 4);
            internalDictionary.Add("five", 5);
            Dictionary<string, object> AnotherDictionary = new Dictionary<string, object>();
            AnotherDictionary.Add("six", 6);
            AnotherDictionary.Add("three", 3);
            AnotherDictionary.Add("seven", 7);
            SomeDictionary.Add("Dictionary1", internalDictionary);
            SomeDictionary.Add("Dictionary2", AnotherDictionary);
            var allinone = (from l in MyList
                           join d in SomeDictionary.SelectMany(s => s.Value) on l equals d.Value.ToString()
                           select d).ToList();
