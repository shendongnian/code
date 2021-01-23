	public partial class MainPage : UserControl, INotifyPropertyChanged
	{
		public class ItemViewModel
		{
			public string Description { get; set; }
		}
		public class GroupViewModel : INotifyPropertyChanged
		{
			public GroupViewModel()
			{
				ContentHeight = double.NaN;
				NotifyPropertyChanged("ContentHeight");
				ExpandCommand = new DelegateCommand<object>(Expand);
			}
			public List<ItemViewModel> Items { get; set; }
			public string Description { get; set; }
			public double ContentHeight { get; set; }
			public DelegateCommand<object> ExpandCommand { get; set; }
			public void Expand(object obj)
			{
				if (double.IsNaN(this.ContentHeight)) this.ContentHeight = 0;
				else this.ContentHeight = double.NaN;
				NotifyPropertyChanged("ContentHeight");
			}
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(string propertyName) { if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); } }
		}
		public List<ItemViewModel> Items { get; set; }
		public List<GroupViewModel> Groups { get; set; }
		public MainPage()
		{
			InitializeComponent();
			this.DataContext = this;
			this.Groups = new List<GroupViewModel>();
			GroupViewModel g1, g2, g3;
			this.Groups.Add(g1 = new GroupViewModel() { Description = "Group with 4 itens", Items = new List<ItemViewModel>() });
			g1.Items.Add(new ItemViewModel() { Description = "item1" } );
			g1.Items.Add(new ItemViewModel() { Description = "item2" } );
			g1.Items.Add(new ItemViewModel() { Description = "item3" } );
			g1.Items.Add(new ItemViewModel() { Description = "item4" } );
			this.Groups.Add(g2 = new GroupViewModel() { Description = "Group with 10 itens", Items = new List<ItemViewModel>() });
			g2.Items.Add(new ItemViewModel() { Description = "item1" } );
			g2.Items.Add(new ItemViewModel() { Description = "item2" } );
			g2.Items.Add(new ItemViewModel() { Description = "item3" } );
			g2.Items.Add(new ItemViewModel() { Description = "item4" } );
			g2.Items.Add(new ItemViewModel() { Description = "item5" } );
			g2.Items.Add(new ItemViewModel() { Description = "item6" } );
			g2.Items.Add(new ItemViewModel() { Description = "item7" } );
			g2.Items.Add(new ItemViewModel() { Description = "item8" } );
			g2.Items.Add(new ItemViewModel() { Description = "item9" } );
			g2.Items.Add(new ItemViewModel() { Description = "item10" } );
			this.Groups.Add(g3 = new GroupViewModel() { Description = "Group with 3 itens", Items = new List<ItemViewModel>() });
			g3.Items.Add(new ItemViewModel() { Description = "item1" } );
			g3.Items.Add(new ItemViewModel() { Description = "item2" });
			g3.Items.Add(new ItemViewModel() { Description = "item3" });
			NotifyPropertyChanged("Groups");
			
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
