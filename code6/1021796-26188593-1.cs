    var viewModel = new SomeViewModel();
    viewModel.ListOfAwesomeStrings = new ObservableCollection<string>();
    viewModel.ListOfAwesomeStrings.Add("Option 1");
    viewModel.ListOfAwesomeStrings.Add("Option 2");
    viewModel.ListOfAwesomeStrings.Add("Option 3");
    this.DataContext = viewModel;
