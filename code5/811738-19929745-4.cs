	private ObservableCollection<SystemModel> _systems = new ObservableCollection<SystemModel>();
	public ObservableCollection<SystemModel> Systems { get { return _systems; } }
    public SystemListViewModel()
    {
        var systems = SystemAPI.Instance.GetSystems();
        foreach (var system in systems)
        {
            Systems.Add(system);
        }
    }
