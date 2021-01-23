    public class RelayCommand : ICommand
    {
    	public Func<bool> CanExecute { get; set; }
    	public Action Execute { get; set; }
    
        public RelayCommand()
        {
        }
    
        public RelayCommand(Action execute)
        {
            Execute = execute;
        }
    
    	#region ICommand Members
    
    	bool ICommand.CanExecute(object parameter)
    	{
    		if (this.CanExecute == null)
    		{
    			return true;
    		}
    		else
    		{
    			return this.CanExecute();
    		}
    	}
    
    	event EventHandler ICommand.CanExecuteChanged
    	{
    		add { CommandManager.RequerySuggested += value; }
    		remove { CommandManager.RequerySuggested -= value; }
    	}
    
    	void ICommand.Execute(object parameter)
    	{
    		this.Execute();
    	}
    
    	#endregion
    }
