    public bool SubsequenceEquals<T>(IEnumerable<T> masterList, IEnumerable<T> childList)
    {
    	// find all indexes 
    	var matches = masterList.Select((s, i) => new {s, i})
    							.Where(m => m.s.Equals(childList.First()))
    							.Select (m => m.i);
    
    	return matches.Any(m => Enumerable.SequenceEqual(childList, masterList
    														   .Skip(m)
    														   .Take(childList.Count())));
    }
