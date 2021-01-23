    SortedList sortinlist = new SortedList();
    SortedDictionary valueOrder = new SortedDictionary<string, string>();
    
    public bool Add(string val1, string val2)
    {
           Reading reading = new Reading(val1, val2);
           sortinlist.Add(val1, val2);
           valueOrder.Add(val2, val1);
           return true;
    }
