    void Main()
    {
    		string data = "1Position1234Article4321Quantity2Position4323Article3323Quantity";
	        var Articles = Indices(data, "Article").Dump("Articles: ");
        	var Posistions = Indices(data, "Position").Dump("Positions :");
        	var Quantities = Indices(data, "Quantity").Dump("Quantities :");
    }
    
    // Define other methods and classes here
    public List<int> Indices(string source, string keyword)
    {
    	var results = new List<int>();
        //source: http://stackoverflow.com/questions/3720012/regular-expression-to-split-string-and-number
    	var temp = Regex.Split(source, "(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)").ToList().Where (r => !String.IsNullOrEmpty(r)).ToList();
        //select the list with index only where key word matches
    	var indices = temp.Select ((v,i) => new {index = i, value = v})
    					  .Where (t => t.value == keyword);
    	foreach (var element in indices)
    	{
    		int val;
            //get previous list entry based on index and parse it
    		if(Int32.TryParse(temp[element.index -1], out val))
    		{
    			results.Add(val);
    		}
    	}
    	return results;
    }
