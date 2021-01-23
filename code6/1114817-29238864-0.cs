    private bool _installationOrderVisibility;
    
            public bool InstallationOrderVisibility
            {
                get
                {
                    return _installationOrderVisibility;
                }
                set
                {
                    _installationOrderVisibility = value;
                    OnPropertyChanged("InstallationOrderVisibility");
                }
            }
