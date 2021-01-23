    //ViewModelBase implements INotifyPropertyChanged, which allows us to call RaisePropertyChanged, and have the UI update
    class MyObject : ViewModelBase
    {
    	private bool isNotPostponed = true;
    	public bool IsNotPostponed
    	{
    		get { return isNotPostponed; }
    		set 
    		{ 
    			isNotPostponed = value; 
    			RaisePropertyChanged("IsNotPostponed");
    		}
    	}
    
        private Command postponeCommand;
        public Command PostponeCommand
        {
    
        	get 
        	{
        		if (postponeCommand == null)
        			postponeCommand = new Command(PostponeCommand);
        		return postponeCommand; 
        	}
        				
        }
        
        private void Postpone(object x)
        {
    		IsNotPostponed = false;
        }
        
        //similar code for Proceed Command
    }
