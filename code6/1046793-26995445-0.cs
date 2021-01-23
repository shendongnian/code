    List<MyObject> results = new List<MyObject>();
    
    for (int i = 5; i < list.Count; i += 5) {
       results.Add(new MyObject(list[i-5], list[i-4], list[i-3], list[i-2], list[i-1]));
    }
    
    // results  now contains your objects
