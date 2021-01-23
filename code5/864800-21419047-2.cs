    public partial class MainWindow : Window
	{
		MainViewModel VM = new MainViewModel();
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this.VM;
		}
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.VM.PopUp = new PopUpViewModel { Message = "Hello World!" };
		}
	}
