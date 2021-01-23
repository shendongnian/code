	public class DBTable
	{
		public List<IDBField> FieldName = new List<IDBField>();
		
		public void AddField<F>(string Name)
		{
			FieldName.Add(new DBField<F>());
		}
	}
