    private string name;
    public string Name
    {
    	get { return name; }
    	set
    	{
    		if (name == value)
        		return;
    		name = value;
    		NotifyOfPropertyChange(() => Name);
    	}
    }
