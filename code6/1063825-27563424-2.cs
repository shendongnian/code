    public class ViewModel
    {
          [Required]
          [ValidateAssignedUserName()]
          public string AssignedUserName { get; set; }
          public IList<SelectListItem> PossibleAssignees { get; set; }
          [Required]
          public string Comment { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class ValidateAssignedUserName : ValidationAttribute
    {
	    private const string _defaultErrorMessage = "Select a user.";
	    public ValidateAssignedUserName()
    		: base(_defaultErrorMessage)
	    { }
    	public override bool IsValid(object value)
	    {
		    string user = value as string;
    		if (user != null && user.Length > 0)
	    	{
		    	return true;
    		}
	    	return false;
	    }
    }
