    class MainViewModel: ViewModel, INavigation
    {
        public ViewModel Selected
        {
            get { return _selected; }
            private set
            {
                _selected = value;
                RaisePropertyChanged();
            }
            public void Show(ViewModel viewModel) { Selected = viewModel; }
        }
    }
