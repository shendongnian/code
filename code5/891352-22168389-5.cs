	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			for (int i = 0; i < 100; i++)
			{
				MyList.Add(new ViewModel());
			}
		}
		//MyList Observable Collection
		public ObservableCollection<ViewModel> MyList { get { return _myList; } }
		private ObservableCollection<ViewModel> _myList = new ObservableCollection<ViewModel>();
	}
