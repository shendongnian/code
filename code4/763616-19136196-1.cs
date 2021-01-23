    private ICommand _Comando;
    public ICommand Comando
    {
        get
        {
            return _Comando;
        }
        set
        {
            _Comando = value;
            OnPropertyChanged("Comando");
        }
    }
