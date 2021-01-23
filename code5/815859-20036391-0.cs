	public struct QuizArgs
	{
		public string Question;
		public string[] Answers;
		public int CorrectIndex;
		public DateTime Timestamp;
	}
	private void quizbtn_Click(object Sender, RoutedEventArgs e)
	{
		var args = new QuizArgs
		{
			Question = "What color is the sky?",
			Answers = new string[] { "Red", "Green", "Blue", "Silver" },
			CorrectIndex = 2,
			Timestamp = DateTime.Now
		};
		this.Frame.Navigate(typeof(Quiz), args);
	}
