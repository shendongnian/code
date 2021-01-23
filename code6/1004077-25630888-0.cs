    public string DynamicXaml
    {
        get { return _dynamicXaml; }
        set
        {
           if (_dynamicXaml != value)
           {
               _dynamicXaml = value;
               RaisePropertyChanged(() => DynamicXaml);
           }
        }
    }
