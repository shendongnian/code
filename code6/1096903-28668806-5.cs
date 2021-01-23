	public partial class MainWindow : Window
	{
		private DataTable table;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void BtnLoad_OnClick(object senderIn, RoutedEventArgs eIn)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == true)
			{
				string content = File.ReadAllText(dialog.FileName);
				table = content.ConvertToDataTable();
				dgData.DataContext = table;
			}
		}
	}
