	//host view model
	class MainModel : ViewModelBase
	{
		private UserControl _content;
		public MainModel() { }
		internal void SetNewContent(UserControl _content)
		{
			ContentWindow = _content;
		}
		public UserControl ContentWindow
		{
			get { return _content; }
			set
			{
				_content = value;
				OnPropertyChanged("ContentWindow");
			}
		}
	}
	//user contol's view model
	class MenuViewModel : ViewModelBase
	{
		MainModel _mainModel;
		RandomModel _model; // <!-- It does nothing important -->
		public ICommand OpenUsersCommand { get; private set; }
 
		public MenuViewModel(MainModel mainModel, RandomModel model )
		{
			this._mainModel = mainModel;
			this._model = model;
			OpenUsersCommand = new RelayCommand(OpenUsers, CanOpenUsers);
		}
		private void OpenUsers(object _param)
		{
			UsersPanelViewModel upmodel = new UsersPanelViewModel(_mainModel, _model);
			UsersPanel up = new UsersPanel();
			up.DataContext = upmodel;
			_mainModel.SetNewContent(up);
		}
		private bool CanOpenUsers(object _param)
		{
			return true;
		}
	}
		//main window function
		public ControlPanel()
		{
			InitializeComponent();
			//create main view model for host
			MainModel mainModel = new MainModel();
			RandomModel model = new RandomModel(); //<!-- It does nothing yet -->
			
			//create view model for user controls
			MenuViewModel viewmodel = new MenuViewModel(mainModel, model);
			ButtonsMenu bm = new ButtonsMenu(); // <!-- We load a default UserControl when we run the program -->
			bm.DataContext = viewmodel;
			//set host's property in our user control
			mainModel.ContentWindow = bm;
			this.DataContext = mainModel;
		}
