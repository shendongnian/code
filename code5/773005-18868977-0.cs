    public List<double> DoublesFromString( string arg)
    {
         var doubles = arg.Split(',');
    	 return doubles.Select(s => Convert.ToDouble(s)).ToList();
    }
