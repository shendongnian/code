 	public class MainViewModel : MyViewModelBase
    {
    	private readonly IDataService _dataService;
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        	// ...
        }
        //..
    }  
