    public class GenericViewRequestedEventArgs : EventArgs
    {
        public GenericViewModel ViewModel { get; private set; }
        public GenericViewRequestedEventArgs(GenericViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
    public class SomeViewModel : ViewModelBase
    {
        private RelayCommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(x => Login());
                return _loginCommand;
            }
        }
        public EventHandler<GenericViewRequestedEventArgs> GenericViewRequested;
        private void OnGenericViewRequested(GenericViewModel viewModel)
        {
            var handler = GenericViewRequested;
            if (handler != null)
                handler(this, new GenericViewRequestedEventArgs(viewModel));
        }
        private void Login()
        {
            // Do login stuff, authenticate etc.
            // Open new window.
            OnGenericViewRequested(_specificViewModel);
        }
    }
