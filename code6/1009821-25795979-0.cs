	internal sealed class Example
	{
		public string Test1 { get; set; }
		public string Test2 { get; set; }
		public string Reserved1 { get; set; }
		public string Reserved2 { get; set; }
	}
	internal sealed class ExampleMap : CsvClassMap<Example>
	{
		public ExampleMap()
		{
			Map(ex => ex.Test1).Index(0);
			Map(ex => ex.Reserved1).Index(1);
			Map(ex => ex.Reserved2).Index(2);
			Map(ex => ex.Test2).Index(3);
		}
	}
