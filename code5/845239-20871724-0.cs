        private String _url;
     	private String _TemplateType;
        private DefineAddinModel _defineAddin;
    
    	public DefineAddinModel DefineAddin
    	{
    		get	{return _defineAddin;}
    		set
    		{ 
    			_defineAddin = value;
    			OnPropertyChanged("DefineAddin");
    		}
    	}
    
        public string URL
        {
        	get { return _url;  }
            set
            	{
                	if (value != _url)
                	{
                    	_url= value;
                    	OnPropertyChanged("URL");
                	}
            	}
        }
    
        public string TemplateType
        {
        	get { return _TemplateType;  }
            set
            {
                if (value != _TemplateType)
                {
                    _TemplateType= value;
                    OnPropertyChanged("URL");
                }
            }
    	}
    	
    	public RelayCommand OnSaved
    	{
    		get{return new RelayCommand(()=>
    										{
    											DefineAddin.URL  = URL	;
    											DefineAddin.TemplateType = TemplateType;
    										})}
    	}
    	
    	
    	public ViewModel()
    	{
    		DefineAddin = new DefineAddinModel();
    	}
