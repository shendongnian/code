    private string _text;
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            OnPropertyChanged("Text");
            
            // There is a special RelayCommand method to notify "CanExecute" changed.
            // After this call, the "CanExecute" state is "re-evaluated" automatically by binding using CanExecute Func passed into RelayCommand constructor.
            _buttonCommand.RaiseCanExecuteChanged();
        }
    }
    private RelayCommand _buttonCommand;
    public ICommand ButtonCommand
    {
        get
        {
            if (_buttonCommand == null)
            {
                _buttonCommand = new RelayCommand(
                    param => this.ButtonCommandExecute(), 
                    param => this.ButtonCommandCanExecute()
                );
            }
            return _buttonCommand;
        }
    }
