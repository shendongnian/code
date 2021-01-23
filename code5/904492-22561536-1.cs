    public class CompareLines : IComparer<string>
    	{
    		public string IncomingFormat { get; set; }
    
    		public CompareLines()
    		{
    			IncomingFormat = "MM\tdd\tyyyy";
    		}
    
    		public int Compare(string first, string second)
    		{
    			var date1 = DateTime.ParseExact(first, IncomingFormat, CultureInfo.InvariantCulture);
    			var date2 = DateTime.ParseExact(second, IncomingFormat, CultureInfo.InvariantCulture);
    
    			return date1.CompareTo(date2);
    		}
    	}
