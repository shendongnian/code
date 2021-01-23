    private bool _internalIHaveDoneThis;
    public bool IHaveDoneThis
    {
    	get{return _internalIHaveDoneThis;} 
    	set
    	{
    		if(_internalIHaveDoneThis != value)
    		{
    			_internalIHaveDoneThis = value; 
    			RaisePropertyChanged(() => IHaveDoneThis);
    			RaisePropertyChanged(() => IHaveDoneAtleastSomething);
    		}
    	}
    }
    
    
    private bool _internalIHaveDoneThat;
    public bool IHaveDoneThat
    {
    	get{return _internalIHaveDoneThat;} 
    	set
    	{
    		if(_internalIHaveDoneThat != value)
    		{
    			_internalIHaveDoneThat = value; 
    			RaisePropertyChanged(() => IHaveDoneThat);
    			RaisePropertyChanged(() => IHaveDoneAtleastSomething);
    		}
    	}
    }
    
    public bool IHaveDoneAtleastSomething 
    { 
        get { return (IHaveDoneThis | IHaveDoneThat); } 
    }
