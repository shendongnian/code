	public class QuestionObject
	{
		public string DataMember { get; set; }
		public String Answer { get; set; }
	}
	
	public class AnswerObject
	{
		public Dictionary<String, String> Questions { get; set; }
		
		public AnswerObject()
		{
			Questions = new Dictionary<String, String>();
			// fill the keys and init the question names
			Enumerable.Range(1, 80).ToList().ForEach(index =>
			{
				Questions.Add(String.Format("Q{0}", index), String.Empty);
			});
		}
	}
