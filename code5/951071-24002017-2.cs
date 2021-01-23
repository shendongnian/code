	public class DynamicDataRecord : DynamicObject 
    {
		private IDataRecord _dataRecordFromReader;
		public DynamicDataRecord(IDataRecord dataRecordFromReader) 
		{ 
			_dataRecordFromReader = dataRecordFromReader; 
		}
	 
		public override bool TryGetMember(GetMemberBinder binder, out dynamic result) 
		{
			result = _dataRecordFromReader[binder.Name];
			return result != null;
		}
	}
