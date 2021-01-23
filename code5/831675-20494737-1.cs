    private string value;
    public string Value
            {
                get
                { return value; }
                set
                {
                    this.value = value;
                    NotifyPropertyChanged("Value");
                }
            }
