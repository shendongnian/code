    protected void Page_Load(object sender, EventArgs e)
    {
    	var dropdownListIds = new List<string>();
    	var allControls = GetControlsRecursively(this);
    	foreach (var ctrl in allControls)
    	{
    		var ddl = ctrl as DropDownList;
    		if (ddl != null)
    		{
    			dropdownListIds.Add(ddl.ID);
    		}
    	}
    }
    
    private List<Control> GetControlsRecursively(Control parent)
    {
    	var allControls = new List<Control>();
    	foreach (Control child in parent.Controls)
    	{
    		allControls.Add(child);
    		allControls.AddRange(GetControlsRecursively(child));
    	}
    	return allControls;
    }
