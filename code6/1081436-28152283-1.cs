	using System.Linq;
	using System.Windows;
	namespace WpfApplication1
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				Degrees = Enumerable.Range(1, 5).Select(x => x * 10 + 100).ToArray();
				DataContext = this;
			}
			public int[] Degrees { get; private set; }
		}
	}
