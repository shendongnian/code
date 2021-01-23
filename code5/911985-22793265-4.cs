    public ICommand SwitchViewsCommand {get; private set;}
    public MainViewModel()
    {
        SwitchViewsCommand = new DelegateCommand((parameter) => CurrentView = Activator.CreateInstance(parameter as Type));
    }
