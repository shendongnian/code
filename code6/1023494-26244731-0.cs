    namespace SuggestionBox.ViewModels
    {
        public class SuggestionBoxViewModel
        {
            public CommentModel Comments { get; set; }
            public DropDownModel Departments { get; set; }
            public SuggestionBoxViewModel()
            {
                Departments = new DropDownModel();
                Departments.SetDropDownList();
                Comments = new CommentModel();
            }
            public int CommentiD 
            { 
                get { return Comments.CommentiD; }
            }
            public string CommentByName 
            { 
                get { return Comments.CommentByName; }
            }
            ...etc.
        }
    }
