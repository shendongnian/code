    List<int> originalList = new List<int>();
    originalList.add(1);
    AddMore(originalList);
    
    private void AddMore(List<int> list)
    {
        // OriginalList will now also contain two objects (Count = 2)
        // Both lists are sharing the same reference and therefore are pointing
        // to the same memory location
        list.Add(2);
        
        // Create a new reference for variable of type List<int>. 
        // This will override list but not originalList 
        // originalList.Count is still 2! 
        list = new List<int>();
        // originalList still has two objects. Not three!
        // The local variable is now pointing to a new/ different memomory location
        // than originalList is pointing to
        list.Add(3)
    }
