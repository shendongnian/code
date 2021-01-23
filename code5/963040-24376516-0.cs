	public class StudyPlanResponse
	{
		public int CODE { get; set; }
		public Dictionary<int, Exam> EXAMS_LIST { get; set; }
		
		public class Exam
		{
			public string CFU { get; set; }
			public string RESULT { get; set; }
			public string SSD { get; set; }
			public string TAF { get; set; }
			public string TEACHING { get; set; }
			public int YEAR { get; set; }
		}
	}
