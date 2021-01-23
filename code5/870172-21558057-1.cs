    public class QuestionsViewModel
    		{
    			public QuestionsViewModel()
    			{
    				Questions = new List<QuestionViewModel>();
    			}
    			public List<SelectListItem> QuestionsSelectList { get; set; }
    			public List<QuestionViewModel> Questions { get; set; }
    		}
