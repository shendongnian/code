	[Serializable]
	public class MyKeyValue {
		public string Key { get; set; }
		public string Value { get; set; }
	}
	
	
	[Serializable]
	public class MasterClass
	{
		public MasterClass() {}
		
		public MasterClass(DataRow row)
		{
			var list = new List<MyKeyValue>();
			foreach (DataColumn col in row.Table.Columns)
			{
				list.Add(new MyKeyValue{Key = col.ColumnName, Value = Convert.ToString(row[col.ColumnName])});
			}
			EntityData = list;
		}
		public IEnumerable<MyKeyValue> EntityData
		{
			get;
			set;
		}
	}
	
	
