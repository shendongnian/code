	public partial class CRUDDataGrid1 : UserControl, INotifyPropertyChanged
	{
		public ObservableCollection<object> AdditionalToolbarItems { get { return _additionalToolbarItems; } }
		private readonly ObservableCollection<object> _additionalToolbarItems = new ObservableCollection<object>();
		public event PropertyChangedEventHandler PropertyChanged;
		
		public UserControl1()
		{
			InitializeComponent();
			_additionalToolbarItems.CollectionChanged +=
				(sender, eventArgs) =>
				{
					PropertyChangedEventHandler handler = PropertyChanged;
					if (handler != null)
						handler(this, new PropertyChangedEventArgs("AdditionalToolbarItems"));
				};
				
			...other constructor code...
		}
	}
