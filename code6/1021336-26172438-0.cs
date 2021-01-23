	public partial class MainWindow : Window
	{
		public MainWindow() 
		{
			InitializeComponent();
			DataContext = this; // set datacontext
		}
		private ObservableCollection<string> test = new ObservableCollection<string>() { "1", "2" };
		public ObservableCollection<string> Test
		{
			get { return test; }
			set { test = value; }
		}
	}
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <StackPanel>
    		<ComboBox ItemsSource="{Binding Path=Test}"/>
    	</StackPanel>
    </Window>
