    private bool _placeSelected;
    
    public BasicModel SelectedPlace {
        get {
            return _selectedPlace;
        }
        set {
            _placeSelected = true;
            _selectedPlace = value;
            RaisePropertyChanged("SelectedPlace");
        }
    }
    
    ListBoxClick = new RelayCommand((o) => {
        if (!_placeSelected) {
            SelectedPlace = _selectedPlace;
        }
        else {
            _placeSelected = false;
        }
    });
