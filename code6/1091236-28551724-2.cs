    public class MainManager : IMainManager
    {
	    //Option A: Property injection with public property
        public IDataManager DataManager { get; set; }
	
	    //Option B: Constructor injection with private member
	    private IDataManager _dataManager;
	    public MainManager (IDataManager dataManager)
	    {
		    _dataManager = dataManager;
	    }
        //This method shows how to consume the DataManager.
        public void MyMethod()
        {
            var row = DataManager.QueryableTable1.FirstOrDefault();
            //Some more logic....
        }
    }
