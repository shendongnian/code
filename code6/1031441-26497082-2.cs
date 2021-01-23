    public partial class MainWindow : Window
	{
		public MainWindowViewModel Model { get; set; }
		public MainWindow()
		{
			Model = new MainWindowViewModel();
			
			InitializeComponent();
			Model.Items.Add("one");
			Model.Items.Add("two");
		}
	}
