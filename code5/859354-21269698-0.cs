    public ICommand CheckLoginCommand
    {
        get 
        {
            if (this.checkLoginCommand == null)
                this.checkLoginCommand = new Command(p => {
                    if (Login != null)
                        Login(this._username, this._password); 
                    else
                        System.Windows.MessageBox.Show("Login DELEGATE IS EMPTY!?!?!"); //keeps firing...
                });
            return this.checkLoginCommand;
        }
    }
