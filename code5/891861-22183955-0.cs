    public IEnumerable<KeyValuePair<String, Int32>> SearchDuplicates(string file){
    	var file = File.ReadLines(file);
    	var pattern = new Regex("[A-Za-z]* [0-9]{2} [0-9]{4} [A-Za-z]*");
    	var results = new Dictionary<string, int>();
    	
    	foreach(var line in file) {
    		foreach(Match match in pattern.Matches(line)) {
    			if(!results.ContainsKey(match.Value))
    				results.Add(match.Value, 0);
    			results[match.Value]++;
    		}
    	}
    	
    	return results.Where(v => v.Value > 1);
    }
