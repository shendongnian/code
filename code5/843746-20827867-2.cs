	public class SearchFilterViewModel
	{
		public string l { get; set; }
		public List<SearchFilterFiltersViewModel> f { get; set; }
	}
	public class SearchFilterFiltersViewModel
	{
		public string v { get; set; }
		public string o { get; set; }
		public string f { get; set; }
		public bool c { get; set; }
	}
