    public string Test
            {
                get
                {
                    return _myInterface.Test;
                }
                set
                {
                    _myInterface.Test = value;
                    OnPropertyChanged();
                }
            }
