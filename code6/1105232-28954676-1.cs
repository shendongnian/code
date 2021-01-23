    DelegateCommand _SaveCommand = null;
    public DelegateCommand SaveCommand
    {
        get
        {
            if (_SaveCommand != null)
                return _SaveCommand;
            _SaveCommand = new DelegateCommand
            (
                () =>
                {
                    // TODO
                }, 
                () => true
            );
            this.PropertyChanged += (s, e) => _SaveCommand.RaiseCanExecuteChanged();
            return _SaveCommand;
        }
    }
