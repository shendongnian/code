    //ViewModelBase implements INotifyPropertyChanged, which allows us to call RaisePropertyChanged, and have the UI update
    class MyObject : ViewModelBase
    {
    	private bool showMe = true;
    	public bool ShowMe
    	{
    		get { return showMe; }
    		set 
    		{ 
    			showMe = value; 
    			RaisePropertyChanged("ShowMe");
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
    		ShowMe = false;
        }
        
        //similar code for Proceed Command
    }
