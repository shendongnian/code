    public class Model
    {
    	public IEnumerable<SelectListItem> Supervisors
    	{
    		get
    		{
    			return new[]
    			{
    				new SelectListItem {Text = "-- select --", Value = ""},
    				new SelectListItem {Text = "Mr. Kevin Thomas", Value = "0"},
    				new SelectListItem {Text = "Ms. Lisa Brown", Value = "1"},
    				new SelectListItem {Text = "Mr. Sail Kapoor", Value = "2"}
    			};
    		}
    	}
    	
    	[RequiredIf("RoleID == 3", ErrorMessage = "Select Head.")]
    	public int? ParentID { get; set; }
        ...
    	
