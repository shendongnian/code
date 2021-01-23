    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			new DraggedWindow(this).Show();
		}
	}
