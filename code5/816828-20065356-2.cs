    public class AnswerView : UserControl
    {
    	public AnswerView(QuestionViewModel q)
    	{
    		switch(q.Type)
    		{
    			case AnswerType.OneAnswer:
    			//Put log for jne answer view generation
    			break;
    			case AnswerType.MultipleAnswers:
    			//Put logic for multiple answers View generation
    			break;
    			default:
    		}
    
    	}
    }
