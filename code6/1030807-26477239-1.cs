	public partial class MainWindow : Window
	{
		public MainWindow()
		{
		    MyCommand = new MyClickCommand();
			InitializeComponent();
			DataContext = this;
		}
		public MyClickCommand MyCommand { get; set; }
	}
	public class MyClickCommand : ICommand 
	{
		public bool CanExecute(object parameter) 
		{
			return true;
		}
		public event EventHandler CanExecuteChanged;
		public void Execute(object parameter)
		{
			MessageBox.Show("click!");
		}
	}
