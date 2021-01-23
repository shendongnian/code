      private static MainViewModel _viewModel;
    
                public static MainViewModel ViewModel
                {
                    get { return _viewModel ?? (_viewModel = new MainViewModel()); }
                }
      
