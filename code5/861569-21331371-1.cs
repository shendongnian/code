            public string UserName
            {
                get
                {
                    return _userName;
                }
                set
                {
                    if (_userName != value)
                    {
                        _userName = value;
                        RaisePropertyChanged(() => UserName);
                    }
                }
            }
