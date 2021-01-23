	void Main()
	{
		var context = new ParserContext();
		context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
		var xaml = @"<Grid><ListBox ItemsSource=""{Binding DataSource.Result}"" /></Grid>";
		var element = (FrameworkElement)XamlReader.Parse(xaml, context);
		element.DataContext = new ProductViewModel();
		
		PanelManager.StackWpfElement(element);
	}
	
	class ProductViewModel
	{
		public ProductViewModel()
		{
			DataSource = new AsyncTaskManager<ObservableCollection<string>>(LoadProductsAsync());
		}
		
		private async Task<ObservableCollection<string>> LoadProductsAsync()
		{
			await Task.Delay(10000);
			return new ObservableCollection<string> { "first", "second", "third" };
		}
		
		public AsyncTaskManager<ObservableCollection<string>> DataSource { get; private set; }
	}
