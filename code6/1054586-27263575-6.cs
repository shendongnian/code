    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    
    	private void TestButton_OnClick(object sender, RoutedEventArgs e)
    	{
    		var vm = TestTabs.DataContext as TestViewModel;
    		MessageBox.Show(string.Format("You selected tab {0}", vm.Selected));
    	}
    }
