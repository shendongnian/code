    class MainViewModel
    {
    	public ObservableCollection<DataGridRowViewModel> Items
    	{
    		get;
    		set;
    	}
    
    	public MainViewModel(){
    		Items = new ObservableCollection<DataGridRowViewModel>{
    			new DataGridRowViewModel("Beep"),
    			new DataGridRowViewModel("Meep")
    		};
    	}
    }
    
    class DataGridRowViewModel
    {
    	public string Alpha {get;set;}
    	
    	public DataGridRowViewModel(string alpha){
    		Alpha = alpha;
    	}
    }
