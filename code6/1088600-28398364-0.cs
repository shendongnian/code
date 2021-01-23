    public string FullName
    {
       get
       {
           return string.Format(
               "{0} {1}",
               this.firstName,
               this.lastName);
       }
    }
    public string FirstName
    {
       get
       {
           return this.firstName;
       }
       set
       {
           if (value != this.firstName)
           {
               this.firstName = value;
               NotifyPropertyChanged(nameof(FirstName));
               NotifyPropertyChanged(nameof(FullName));
            }
       }
    }
    public string LasttName
    {
       get
       {
           return this.lastName;
       }
       set
       {
           if (value != this.lastName)
           {
               this.lastName = value;
               NotifyPropertyChanged(nameof(LasttName));
               NotifyPropertyChanged(nameof(FullName));
            }
       }
    }
