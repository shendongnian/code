	[DelimitedRecord(",")]
	public class Record
	{
		public int Id;
		public string Name;
		public string SomeProperty
		{
			get { return someProperty; }
			set { someProperty = value; }
		}
		[FieldHidden]
		private string someProperty;
	}
