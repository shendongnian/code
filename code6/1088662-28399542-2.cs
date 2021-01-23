	public class IndexViewModel
	{
		public IEnumerable<ShelveModel> Shelves { get; set; }
	}
	public class ShelveModel
	{
		public string Name { get; set; }
		public int BookCount { get ; set; }
	}
