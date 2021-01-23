    public SortedSet<string> DoSomething(SortedSet<string> old)
    {
       SortedSet<string> newSet = new SortedSet<string>();
    
       foreach(string curr in old)
         newSet.Add(curr.Replace("B", "X"));
       return newSet;
    }
