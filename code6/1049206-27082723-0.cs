            public Place SelectedPlace
            {
                get { return _selectedPlace; }
                set
                {    _selectedPlace = value; 
                     RaisePropertyChanged("SelectedPlace")}
                }
            }
