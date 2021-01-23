    public OpeningModel Opening
    {
        get { return opening; }
        set
        {
            opening = value;
            NotifyPropertyChanged("Opening");
            UpdateCertificates();
        }
    }
