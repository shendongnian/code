	class MainWindowViewModel : ObservableObject
	{
	    private Authentication auth = new Authentication();
	
	    public MainWindowViewModel()
	    {
	        LogIn = new RelayCommand(() => auth.SetView(), () => (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) ? false : true);
	        
	        // Echo the PropertyChanged events from our auth class
	        auth.PropertyChanged += this.PropertyChanged;
	        auth.Start();
	    }
	
	    public ICommand LogIn { get; set; }
	    public Visibility Auth
	    {
	        get
	        {
	            return auth.Auth;
	        }
            set
            {
                auth.Auth = value;
                NotifyPropertyChanged();
            }
	    }
	    public Visibility Tab
	    {
	        get
	        {
	            return auth.Tab;
	        }
            set
            {
                auth.Tab = value;
                NotifyPropertyChanged();
            }
	    }
	}
