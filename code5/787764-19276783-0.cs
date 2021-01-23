	public class CsvFile
	{  
		private IEnumerable<DataRow> rows = cc.Read<DataRow>(_filePath, _inputFileDescription);
		//...		
		public IEnumerable<DataRow> Rows { get { return rows; } }
	}
	
