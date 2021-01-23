	public class TableCommon
	{
		public string Name { get; set; }
	}
	public class Table1 : TableCommon
	{}
	public class Table2 : TableCommon
	{}
	public class Table3 : TableCommon
	{}
	public class Example
	{
		public void Test2()
		{
			var t1 = new List<Table1>();
			var t2 = new List<Table2>();
			var t3 = new List<Table3>();
			
			var rpt1 = FilterData(t1);
			var rpt2 = FilterData(t2);
			var rpt3 = FilterData(t3);
		}
		public IEnumerable<T> FilterData<T>(IEnumerable<T> data) where T : TableCommon
		{
			var filter = "hello";
			Func<T, bool> pred = (x) => x.Name.StartsWith(filter);
			return data.Where(pred);
		}
	}
