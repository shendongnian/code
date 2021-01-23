		class Question : CommmonFunctions
		{
			private List<string> Choices;
		
			public Question()
			{
				Choices = new List<string>();
				_retries = 1;
				_score = 10;
			}
		
			public string QuestionText { set; get; }
			public void AddChoice(string ChoiceText)
			{
				Choices.Add(ChoiceText);
			}
			public int SetAnswer { set; get; }
		
			private int _retries;
			public int Retries 
			{ 
				get{ return _retries; }
				set 
				{
					if (!RetriesReadonly)
						_retries = value;
				}
			}
			
			private int _score;
			public int Score 
			{ 
				get{ return _score; }
				set 
				{
					if (!ScoreReadonly)
						_score = value;
				}
			}
			
			public virtual bool ScoreReadonly {get{return false;}}
			public virtual bool RetriesReadonly {get{return false;}}
		}
			
		class QuestionTypeA : Question
		{
            // question of type A can't change score
			public override bool ScoreReadonly { get {return true;}}
		}
