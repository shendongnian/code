     public class RadioButtonQuestion
     {
	    public string ChoiceQuestion { get; set; }
	    public string answer { get; set; }
	    public List<AnswerOption> ListOfAnswerOptions { get; set; }
     }
     public class AnswerOption
	 {
		public string individualRadioButtonText { get; set; }
		public bool IsChecked { get; set; }
	 }
