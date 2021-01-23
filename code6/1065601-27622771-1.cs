    public bool TabItem1IsSelected
    {
    	get { return _tabItem1IsSelected; }
    	set
    	{
    		if (_tabItem1IsSelected)
    		{
    			if (!value)
    			{
    				// Check to see if user has updated
    
    				if (!userUpdated)
    				{
    					value = true;
    				}
    			}
    		}
    		_tabItem1IsSelected = value;
    		RaisePropertyChanged();
    	}	
    }
