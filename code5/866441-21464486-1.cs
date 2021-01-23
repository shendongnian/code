    // If you have a named IViewModel
    // public ViewAccountsView([Dependency("ViewAccountsViewModelName")]IViewModel viewModel)
    public ViewAccountsView(IViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
