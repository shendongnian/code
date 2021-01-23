    private Person _person;
    public Person Person
    {
        get { return _person; }
        set
        {
            if (Equals(value, _person)) return;
            if (_person != null)
                _person.PropertyChanged -= PersonPropertyChanged;
            _person = value;
            if(_person != null)
                _person.PropertyChanged += PersonPropertyChanged;
            OnPropertyChanged("Person");
        }
    }
