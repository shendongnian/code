    public IEnumerable<object> GetListOfObject()
    {
    	foreach (var prod in TenMostExpensiveProducts().Tables[0].AsEnumerable())
    	{
    		yield return prod;
    	}
    }
