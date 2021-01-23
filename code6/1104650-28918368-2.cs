		public interface CommmonFunctions
		{
			string QuestionText { set; get; }
			void AddChoice(string ChoiceText);
			int SetAnswer { set; get; }
			int Score { set; get; }
			bool ScoreReadonly {get;}
			int Retries { set; get; }
			bool RetriesReadonly  {get;}
		}
