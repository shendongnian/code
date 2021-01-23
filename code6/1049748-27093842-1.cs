	public class CountryVm
	{
		public CountryVm(string name)
		{
            //since Name is a simple property it's better to initialize it in constructor
            //because Name is neither a dependency property nor notifies about it changes.
            //see DependencyProperty and INotifyPropertyChanged documentation
            Name = name;
		}
		public string Name { get; set; }
        //an observable collection notifies about any changes made in it
		public ObservableCollection<SectorVm> Sectors { get { return _sectors; } }
		private ObservableCollection<SectorVm> _sectors = new ObservableCollection<SectorVm>();
    }
	public class SectorVm
	{
		public SectorVm(string name)
		{
            Name = name;
		}
		public string Name { get; set; }
		public ObservableCollection<EntityVm> Entities { get { return _entities; } }
		private ObservableCollection<EntityVm> _entities = new ObservableCollection<EntityVm>();
    }
	public class EntityVm
	{
		public EntityVm(string name)
		{
            Name = name;
		}
		public string Name { get; set; }
    }
