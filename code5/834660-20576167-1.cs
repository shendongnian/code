   	public partial class Window1 : Window
	{
		public MyViewModel MyViewModel {get; set;}
		public Window1()
		{
			InitializeComponent();
			this.MyViewModel = new MyViewModel { FontSize = 80 };
		}
	}
