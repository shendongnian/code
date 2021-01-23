    void Main()
    {
    	var data = new List<string>() { "Entry1", "Metadata1", "Metadata2", 
                                        "Entry2", "Metadata3", "Metadata4" };
    					   
    	PairWithGroup(data).GroupBy(t=>t.Item1).Dump();
    }
    
    private IEnumerable<Tuple<string,string>> PairWithGroup(IEnumerable<string> input) {
    	string groupName = null;
    	foreach (var entry in input) {
    		if (entry.StartsWith("Entry")) {
    			groupName = entry;
    		}
    		yield return Tuple.Create(groupName, entry);
    	}
    }
