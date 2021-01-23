    public string TextTest
    {
        get { return this.TextTest; } << WILL CAUSE A STACK OVERFLOW
        set
        {
            this.textTest = value;
            NotifyPropertyChanged();
        }
    }
