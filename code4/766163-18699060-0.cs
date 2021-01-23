    public override string DisplayName
    {
        get { return base.DisplayName; }
        protected set
        {
            if (base.DisplayName == value)
                return;
            base.DisplayName = value;
            OnPropertyChanged("DisplayName");
        }
    }
