	using System.Windows;
	using System.Windows.Controls;
	namespace SOWPF
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				var carViewModel = new CarViewModel();
                carViewModel.LoadCars();
				this.DataContext = carViewModel;
			}
		}
	}
