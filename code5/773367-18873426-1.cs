    OrderedDictionary newDict = new OrderedDictionary();
    foreach(DictionaryEntry entry in OriginalDictionary)
    {
         MyClass x = new MyClass();
         x.myProp1 = entry.Value.myProp1 as primitive value;
         x.myProp2 = entry.Value.myProp2 as primitive value;
         newDict[entry.Key] = x;
    }
