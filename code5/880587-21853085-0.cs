    public MyMasterViewModel()
    {
        ClearSelectionCommand = new RelayCommand(
            () => SelectedNestedViewModel = null, 
            () => SelectedNestedViewModel != null);
    }
    
    public ObservableCollection<MyNestedViewModel> NestedViewModels { /* ... */ }
    
    public MyNestedViewModel SelectedNestedViewModel
    {
        get { return selectedNestedViewModel; }
        set
        {
            if (selectedNestedViewModel != value)
            {
                selectedNestedViewModel = value;
                OnPropertyChanged("SelectedNestedViewModel");
            }
        }
    }
    private MyNestedViewModel selectedNestedViewModel;
    
    public ICommand ClearSelectionCommand { get; private set }
