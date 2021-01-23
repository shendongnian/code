    public class MyViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public ICommand OkCommand { get; private set; }
    
            public MyViewModel()
            {
                OkCommand = new GeneralCommand<object>(ExecuteOkCommand, param => CanExecuteCommand());
            }
    
            private void ExecuteOkCommand(object parameter)
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;
            }
    
            private bool CanExecuteCommand()
            {
                return true;
            }
        }
