    	public class Main
    {
    	//your 26 questions stored in this variable
    	public List<Question> questions;
    	//current question shown
    	public Question currentQuestion;
		
		public Main()
		{
			//initiate List
			questions = new List<Question>();
			//add question no.1
			var question1 = new Question();
			question1.No = 1;			
			question1.QuestionText = "What should I ask here?";
			question1.isAnswered = false;
			questions.Add(question1);
			//TODO: add question no.2 to 26
			
			//set current question to question no.1
			currentQuestion = question1;
		}
    	
    	private void nextquestion_click(object sender, eventargs e)
    	{
    		for(int i=1; i<=questions.Count; i++)
    		{
    			int nextQuestionNo = ((currentQuestion.No+i)%questions.Count);
    			if(!questions[nextQuestionNo].isAnswered)
    			{
    				//next unanswered question found. set that as current question
    				//then stop loop
    				currentQuestion = questions[nextQuestionNo];
    				break;
    			}
    		}
    		
    		//TODO: update the UI to show currentQuestion
    	}
    }
