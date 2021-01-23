    [NotifyPropertyChanged]
    public class ActivateViewModel
    {
        private readonly DelegateCommand activateCommand;
        private string password;
        
        public ActivateViewModel()
        {
            activateCommand = new DelegateCommand(Activate, () => !string.IsNullOrEmpty(Password));
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                activateCommand.RaiseCanExecuteChanged(); // To re-evaluate CanExecute.
            }
        }
        
        public ICommand ActivateCommand
        {
            get { return activateCommand; }
        }
        
        private void Activate()
        {
            // ...
        }
    }
