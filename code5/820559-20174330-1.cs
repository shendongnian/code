    public class Main
    {
    	//your 26 questions stored in this variable
    	public List<Question> questions;
    	//current question shown
    	public Question currentQuestion;
    	
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
