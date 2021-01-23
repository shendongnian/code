	public enum SortDirection
	{
		Ascending,
		Descending
	}
	public class SortOption
	{
		public string FieldName { get; set; }
		public SortDirection Direction { get; set; }
		public SortOption(string fieldName, SortDirection direction)
		{
			FieldName = fieldName;
			Direction = direction;
		}
	}
