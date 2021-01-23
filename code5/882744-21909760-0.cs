    Dictionary<int, List<User>> myDictionary = ...;
    // Still a reference to the original dictionary
    Dictionary<int, IEnumerable<User>> castDictionary = myDictionary;
   
    // If the line above was possible, what would this do? (A HashSet<T> is not a List<T>)
    castDictionary.Add(5, new HashSet<User>());
