    public List<double> DoublesFromString( string arg)
    {
         var doubles = arg.RemoveSplit(',');
    	 return doubles.Select(s => Convert.ToDouble(s, CultureInfo.InvariantCulture)).ToList();
    }
