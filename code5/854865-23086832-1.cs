    public partial class App : Application
    {
	private static ToDoDataViewModel _viewModel;
        public static ToDoDataViewModel ViewModel
        {
            get { return _viewModel; }
        }
	
	//other methods of App
	
	public App()
	{
		//place this code at the and of the contructor
		
		CreateDb();
	}
	
	private void CreateDb()
	{
		using(var db=new ToDoDataContext(ToDoDataContext.DBConnectionString))
		{
			if(!db.DatabaseExists())
			{
				db.CreateDatabase();
			}
		}
		
		_viewModel=new ToDoDataViewModel(ToDoDataContext.DBConnectionString);
		_viewModel.LoadCollectionsFromDatabase();
	}
