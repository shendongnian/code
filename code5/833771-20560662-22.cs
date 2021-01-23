    public sealed class FatherViewModel : ViewModelBase
    {
        private SonViewModel _sonViewModel;
        public FatherViewModel()
        {
            CreateSonViewModel = new RelayCommand(OnCreateUserControViewModel);
            RemoveSonViewModel = new RelayCommand(OnRemoveUserControlViewModel);
        }
        public SonViewModel SonViewModel
        {
            get { return _sonViewModel; }
            private set { Set(() => SonViewModel, ref _sonViewModel, value); }
        }
        public ICommand CreateSonViewModel { get; private set; }
        public ICommand RemoveSonViewModel { get; private set; }
        private void OnCreateUserControViewModel()
        {
            SonViewModel = new SonViewModel();
            SonViewModel.Event += OnSonViewModelEvent;
        }
        private void OnSonViewModelEvent(object sender, EventArgs args)
        {
            MessageBox.Show("I got here!");
        }
        private void OnRemoveUserControlViewModel()
        {
            if (SonViewModel != null)
            {
                SonViewModel.Event -= OnSonViewModelEvent;
                SonViewModel = null;
            }
        }
    }
