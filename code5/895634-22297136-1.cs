    private void AddMore(ref List<int> list)
    {
        // OriginalList will now also contain two objects (Count = 2)
        // Both (original and copy) are pointing to the same values since the variables 
        // are now equal
        list.Add(2);
        
        // This creates a new reference for BOTH variables!
        // originalList.Count is now 0
        list = new List<int>();
        // Both list's count is now 1!
        list.Add(3);
    }
