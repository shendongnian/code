    var list = new List<string>();
    
    list.Add("Lost 04x01");
    list.Add("Lost 04x02");
    list.Add("Lost 4x3");
    list.Add("Lost 4x04");
    list.Add("Lost S04E05");
    list.Add("Lost S04E6");
    
    Regex regex = new Regex(@"S?\d{1,2}[X|E]?\d{1,2}", RegexOptions.IgnoreCase);
    
    foreach (string file in list) {
    	if (regex.IsMatch(file))
    	{
    		// true
    	}
    }
