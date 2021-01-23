	public class ReportObjectInformation<TOne, TTwo>
	{
		public string tableName { get; set; }
		public int progressBarValue { get; set; }
		public int rowCount { get; set; }
		public bool canConnect { get; set; }
		public int index { get; set; }
		public string summaryFile { get; set; }
		public string reportFile { get; set; }
		public string errorFile { get; set; }
		public List<TOne> listOne { get; set; }  
		public List<TTwo> listTwo { get; set; }  
	}
