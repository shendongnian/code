	public class SearchFilterViewModel
	{
		public string logic { get; set; }
		public List<SearchFilterFiltersViewModel> filter { get; set; }
	}
	public class SearchFilterFiltersViewModel
	{
		public string value { get; set; }
		public string oper { get; set; }
		public string field { get; set; }
		public bool ignoreCase { get; set; }
	}
