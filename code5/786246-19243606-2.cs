    public bool CanExecuteLogInCommand
    {
        get
        {
            return !string.IsNullOrWhiteSpace(this.Username) && !string.IsNullOrWhiteSpace(this.Password);
        }
    }
        public RelayCommand LogInCommand
        {
            get
            {
                // or you can create instance in constructor: this.LogInCommand = new RelayCommand(this.ExecuteLogInCommand, () => this.CanExecuteLogInCommand);
                return this._logInCommand ?? (this._logInCommand = new RelayCommand(this.ExecuteLogInCommand, () => this.CanExecuteLogInCommand));
            }
        }
        public string Username
        {
            get { return this._username; }
            set
            {
                // a) shorter alternative -> "True if the PropertyChanged event has been raised, false otherwise"
                if (this.Set(() => this.Username, ref this._username, value))
                {
                    // raise CanExecuteLogInCommand
                    this.LogInCommand.RaiseCanExecuteChanged();
                }
                // b) longer alternative
                //if (value == this._username) { return; }
                //this._username = value;
                //this.RaisePropertyChanged(() => this.Username);
                //this.LogInCommand.RaiseCanExecuteChanged();
            }
        }
        
        public string Password
        {
            get { return this._password; }
            set
            {
                if (this.Set(() => this.Password, ref this._password, value))
                {
                    this.LogInCommand.RaiseCanExecuteChanged();
                }
            }
        }
