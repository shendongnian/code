    private ObservableCollection<UserType> _listUserTypes = new ObservableCollection<UserType>();
                public ObservableCollection<UserType> UserTypes
                {
                    set
                    {
                        _listUserTypes = value;
        
                    }
                    get
                    {
                        return _listUserTypes;
                    }
                }
