    public enum AnswerType {OneAnswer, MultipleAnswers}
    
    public class QuestionViewModel : ViewModel
    {
    	public AnswerType type;
    	public string[] Answers;
    }
