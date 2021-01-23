	public class AdvancedFiltersEx: AdvancedFilters 
	{
		public AdvancedFiltersEx( Principal principal ): 
			base(principal) { }
		public void Person()
		{
			this.AdvancedFilterSet("objectCategory", "person", typeof(string), MatchType.Equals);
			this.AdvancedFilterSet("msExchResourceMetaData", "ResourceType:Room", typeof(string), MatchType.NotEquals);
		}
	}
    //...
	for( int i = 0; i < 10; i++ )
	{
		uint count = 0;
		Stopwatch timer = Stopwatch.StartNew();
		PrincipalContext context = new PrincipalContext(ContextType.Domain);
		UserPrincipalEx filter = new UserPrincipalEx(context);
		filter.Enabled = true;
		filter.AdvancedSearchFilter.Person();
		PrincipalSearcher search = new PrincipalSearcher(filter);
		DirectorySearcher ds = search.GetUnderlyingSearcher() as DirectorySearcher;
		if( ds != null )
			ds.PageSize = 1000;
		foreach( UserPrincipalEx result in search.FindAll() )
		{
			string canonicalName = result.CanonicalName;
			count++;
		}
		timer.Stop();
		Console.WriteLine("{0}, {1} ms", count, timer.ElapsedMilliseconds);
	}
