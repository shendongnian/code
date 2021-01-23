    public sealed class MainWindowViewModel : ViewModelBase
    {
        private UserControlViewModel _userControlViewModel;
        public MainWindowViewModel()
        {
            CreateUserControlViewModelCommand = new RelayCommand(OnCreateUserControViewModel);
            RemoveUserControlViewModelCommand = new RelayCommand(OnRemoveUserControlViewModel);
        }
        public UserControlViewModel UserControlViewModel
        {
            get { return _userControlViewModel; }
            private set { Set(() => UserControlViewModel, ref _userControlViewModel, value); }
        }
        public ICommand CreateUserControlViewModelCommand { get; private set; }
        public ICommand RemoveUserControlViewModelCommand { get; private set; }
        private void OnCreateUserControViewModel()
        {
            UserControlViewModel = new UserControlViewModel();
            UserControlViewModel.Event += OnUserControlViewModelEvent;
        }
        private void OnUserControlViewModelEvent(object sender, EventArgs args)
        {
            MessageBox.Show("I got here!"); // violation of MVVM for sake of simplicity
        }
        private void OnRemoveUserControlViewModel()
        {
            if (UserControlViewModel != null)
            {
                UserControlViewModel.Event -= OnUserControlViewModelEvent;
                UserControlViewModel = null;
            }
        }
    }
    
