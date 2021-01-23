    List<int> ints = new List<int>();
    GetName(ints); // calls the IEnumerable version
    
    object intsObj = (object)ints;
    GetName(intsObj); // calls the non-IEnumerable version.
