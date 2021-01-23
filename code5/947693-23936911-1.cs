    private static MainViewModel viewModel = null;
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();
                return viewModel;
            }
        }
