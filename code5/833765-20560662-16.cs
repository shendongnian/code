    public sealed class FatherViewModel : ViewModelBase
    {
        private SonViewModel _sonViewModel;
        public FatherViewModel()
        {
            CreateUserControlViewModel = new RelayCommand(OnCreateUserControViewModel);
            RemoveUserControlViewModel = new RelayCommand(OnRemoveUserControlViewModel);
        }
        public SonViewModel SonViewModel
        {
            get { return _sonViewModel; }
            private set { Set(() => SonViewModel, ref _sonViewModel, value); }
        }
        public ICommand CreateUserControlViewModel { get; private set; }
        public ICommand RemoveUserControlViewModel { get; private set; }
        private void OnCreateUserControViewModel()
        {
            SonViewModel = new SonViewModel();
            SonViewModel.Event += OnUserControlViewModelEvent;
        }
        private void OnUserControlViewModelEvent(object sender, EventArgs args)
        {
            MessageBox.Show("I got here!");
        }
        private void OnRemoveUserControlViewModel()
        {
            if (SonViewModel != null)
            {
                SonViewModel.Event -= OnUserControlViewModelEvent;
                SonViewModel = null;
            }
        }
    }
