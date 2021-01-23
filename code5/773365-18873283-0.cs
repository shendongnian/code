    Dictionary<int, MyObject> original = new Dictionary<int, MyObject>();
    ... code to populate original ...
    
    Dictionary<int, MyObject> deepCopy = new Dictionary<int, MyObject>();
    	
    foreach(var v in a)
    {
        MyObject clone = v.Value.Clone();
        b.Add(v.Key, clone);
    }
