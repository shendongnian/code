    public List<GenderTypes> Genders
            {
                get
                {
                    return _genders;
                }
                set
                {
                    _genders = value;
                    OnPropertyChanged("Genders");
                }
            }
