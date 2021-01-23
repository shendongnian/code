	public class TreeNodeVm
	{
		public TreeNodeVm(string name)
		{
            Name = name;
		}
		public string Name { get; set; }
		public ObservableCollection<TreeNodeVm> Children { get { return _children; } }
		private ObservableCollection<TreeNodeVm> _children = new ObservableCollection<TreeNodeVm>();
    }
