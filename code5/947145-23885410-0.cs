	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
			
			this.DataContext = new MyViewModel();
			var myValue = this.DataContext.GetType().GetProperty("MyIntValue").GetValue(this.DataContext, null);
		}
	}
	public class MyViewModel
	{
		private int myIntValue = 6;
		public int MyIntValue
		{
			get
			{
				return this.myIntValue;
			}
		}
	}
