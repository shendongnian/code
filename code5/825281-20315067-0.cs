            private Person_selectedperson;
    
            public Person SelectedPerson
            {
                get { return _selectedperson; }
                set
                {
                    _selectedperson = value;
                    OnPropertyChanged("SelectedPerson");
                }
            }
