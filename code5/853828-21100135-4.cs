    public class User
    	{
    		public ActionMethodEnum ActionMethod { get; set; }
    
    		[ConditionalRequired(ActionMethodEnum = ActionMethodEnum.Update, ActionMethodFieldName = "ActionMethod")]
    		[StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    		[Display(Name = "First Name")]
    		public string FirstName { get; set; }
    
    		[ConditionalRequired(ActionMethodEnum = ActionMethodEnum.Change, ActionMethodFieldName = "ActionMethod")]
    		[Display(Name = "Last Name")]
    		[StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    		public string LastName { get; set; }
    	}
