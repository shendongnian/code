	public class MainViewModel
	{
		public ObservableCollection<ObservableCollection<Customer>> Customers { get; set; }
		
		public MainViewModel()
		{
			Customers = new ObservableCollection<ObservableCollection<Customer>>();
		}
	}
