    namespace SuggestionBox.ViewModels
    {
        public class SuggestionBoxViewModel
        {
            public CommentModel Comments { get; set; }
            public IEnumerable<string> Departments { get; set; }
            public string SelectedDepartment { get; set; }
            public SuggestionBoxViewModel()
            {
                Departments = new [] {"Engineering","Sales"};
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
        }
    }
