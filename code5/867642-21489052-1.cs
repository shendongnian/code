    public String ProjectName
    {
    	get { return projectName; }
    	set
    	{
    		if (value != projectName)
    		{
    			projectName = value;
    			SetError(() => ProjectName, ValidateProjectName());
    			RaisePropertyChanged(() => this.ProjectName);
    		}
    	}
    }
