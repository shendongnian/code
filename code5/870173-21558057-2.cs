    public class QuestionsViewModel
    		{
    			public QuestionsViewModel()
    			{
    				SelectedQuestions = new List<QuestionViewModel>();
    			}
    			public List<SelectListItem> QuestionsSelectList { get; set; }
    			public List<QuestionViewModel> SelectedQuestions { get; set; }
    		}
