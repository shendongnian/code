	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();
			// Sample code to localize the ApplicationBar
			Items = new ObservableCollection<Object>();
		}
		public ObservableCollection<Object> Items { get; set; }
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Items.Add(new Object() { Value = "A" });
			// This works as expected
			//Items.Add(Guid.NewGuid().ToString());
		}
	}
	public class Object
	{
		public string Value { get; set; }
		public override string ToString()
		{
			return Value;
		}
	}
