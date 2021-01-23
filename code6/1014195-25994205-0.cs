    private DateTime dateTimeField;
    
    public System.DateTime dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                if ((dateTimeField.Equals(value) != true))
                {
                    this.dateTimeField = value;
                    this.OnPropertyChanged("dateTime");
                }
            }
        }
