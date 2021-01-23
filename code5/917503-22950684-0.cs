    internal ViewModel viewModel { get; set; }
    public View()
    {
          DataContext = (viewModel = new ViewModel());
    }
