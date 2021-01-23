    public class Sum : INotifyPropertyChanged
    {	
    	private ICommand _addOneCommand;
        public ICommand AddOneCommand
        {
            get 
            {
                return _addOneCommand
                    ?? (_addOneCommand = new ActionCommand(() => 
                    {
                        EnteredVal += "1";
                    }));
            }
        }
    	.....
    	.....
    }
