	public class HierarchyMenuItem : NotificationObject
	{
		public ICommand Command { get; set; }
		public string Header { get; set; }
		public string CommandParameter { get; set; }
		public ObservableCollection<HierarchyMenuItem> Children { get; set; }
	}	
