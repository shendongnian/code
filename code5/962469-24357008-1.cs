	public class DBField<T> : IDBField
	{
		public List<T> RecordSet = new List<T>();
		
		IList IDBField.RecordSet
		{
			get
			{
				return this.RecordSet;
			}
		}
		
		Type IDBField.FieldType
		{
			get
			{
				return typeof(T);
			}
		}      
	}
