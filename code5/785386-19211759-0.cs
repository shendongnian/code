     private int _topp
    public int topp
            {
                get { return _topp; }
                set
                {
                    if (value != _topp)
                    {
                        _topp = value;
                        NotifyPropertyChanged();
                    }
                }
            }
