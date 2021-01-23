    private dynamic _visibilities;
    public dynamic Visibilities
        {
            get { return _visibilities; }
            set { _visibilities = value; RaisePropertyChanged("Visibilities"); }
        }
