	public class FilterField
	{
		public string Field { get; set; }
		public Dictionary<string,object> Data { get; set; }
	}
	public interface IFilter
	{
		FilterField[] filter { get; set; }
	}
