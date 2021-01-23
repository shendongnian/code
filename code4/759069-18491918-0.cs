     public string Email
        {
            get
            {
                return this.CurrentUser.Email;
            }
            set
            {
                this.CurrentUser.Email = value;
                this.OnPropertyChanged("Email");
            }
        }
