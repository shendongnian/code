    private string _text { get; set; }
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            OnPropertyChanged("Text");
            ButtonCommandCanExecute();
        }
    }
    private ICommand _buttonCommand;
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
    private bool ButtonCommandCanExecute()
    {
        if (this.Text.Length < 5)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void ButtonCommandExecute()
    {
        this.Text = "Text changed";
    }
    public MainWindowViewModel()
    {
        //
    }
