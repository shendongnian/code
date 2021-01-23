    /// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public sealed partial class MainWindow
	{
        ViewModel myViewModel;
		public MainWindow()
		{
            ...
            myViewModel = new ViewModel();
            mySparrowChart.DataContext = myViewModel;
        }
    }
