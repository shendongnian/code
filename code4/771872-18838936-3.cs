    void Main()
    {
    	List<string> strings = Enumerable.Range(1,10).Select(x=>x.ToString()).ToList();
    	List<decimal> decimals = Enumerable.Range(1,100).Select(x=>(Decimal)x).ToList();
    	
    	var detailsRows = decimals.Partition(10)
    							  .Select((details, row) => new {HeaderRow = row, DetailsRows = details});
    	var headerRows = strings.Select((header, row) => new {HeaderRow = row, Header = header});
	
    	var final = headerRows.Join(detailsRows, x=>x.HeaderRow, x=>x.HeaderRow, (header, details) => new {Header = header.Header, Details = details.DetailsRows});
    }
    public static class Extensions
    {
    	public static IEnumerable<List<T>> Partition<T>(this IEnumerable<T> source, Int32 size)
    	{
    		for (int i = 0; i < Math.Ceiling(source.Count() / (Double)size); i++)
    			yield return new List<T>(source.Skip(size * i).Take(size));
    	}
    }    
