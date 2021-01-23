    private RelayCommand _KeyDownCommand;
    public ICommand KeyDownCommand
    {
        get
        {
            if (this._KeyDownCommand == null)
                this._KeyDownCommand = new RelayCommand(param => this.CheckKeysDown());
            
            return this._KeyDownCommand;
        }
    }
