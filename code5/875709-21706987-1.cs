    var addedKeys = NewDictionary.Keys.Except(OriginalDictionary.Keys);
    var removedKeys = OriginalDictionary.Keys.Except(NewDictionary.Keys);
    var comparer = new DictionaryComparer<string, string>();
    var editedValues = OriginalDictionary.Where(pair =>
        comparer.Equals(pair.Value, NewDictionary[pair.Key]));
