    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		public List<Item> Items
		{
			get
			{
				var list = new List<Item>();
				list.Add(new Item{ Date =  DateTime.Now});
				list.Add(new Item { Date = DateTime.Now.AddDays(1) });
				return list;
			}
		}
	}
	public class Item
	{
		public DateTime Date { get; set; }
		public string DisplayDate
		{
			get { return DateTime.Now.Date == Date.Date ? Date.ToString("dd.MM.yyyy HH:MM:SS") : Date.ToString("dd.MMMM.yyyy"); }
		}
	}
