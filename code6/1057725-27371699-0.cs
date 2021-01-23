    public string _hidWorkDirName
    {
    	get
    	{
    		if (ViewState["WorkDirName"] != null)
    		{
    			return (string)ViewState["WorkDirName"];
    		}
    		return string.Empty;
    	}
    	set
    	{
    		ViewState["WorkDirName"] = value;
    	}
    }
