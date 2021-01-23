    async Task<ObservableCollection<string>> GetInstancesAsync()
    {
      var instances = await TaskEx.Run(() => Agent.GetInstances());
      return new ObservableCollection<string>(instances);
    }
    private readonly INotifyTaskCompletion<ObservableCollection<string>> _instancesAsync;
    public INotifyTaskCompletion<ObservableCollection<string>> InstancesAsync
    { get { return _instancesAsync; } }
    private string _instance;
    public string Instance
    {
      get { return _instance; }
      set
      {
        _instance = value;
        raisePropertyChanged("Instance");
        ProjectsAsync = NotifyTaskCompletion.Create(GetProjetsAsync(value));
      }
    }
    private INotifyTaskCompletion<ObservableCollection<string>> _projectsAsync;
    public INotifyTaskCompletion<ObservableCollection<string>> ProjectsAsync
    {
      get { return _projectsAsync; }
      set
      {
        _projectsAsync = value;
        raisePropertyChanged("ProjectsAsync");
      }
    }
