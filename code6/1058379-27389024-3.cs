    public ObservableCollection<Module> Modules { get; private set; }
    public ICommand LockToggleCommand { get; private set; }
    public ViewModel()
    {
        LockToggleCommand = new DelegateCommand<Module>(module => {
            apiService.Lock(module);
        });
    }
