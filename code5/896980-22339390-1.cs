    private ObservableCollection<Country> _countries;
    private ICollectionView _european;
    private ICollectionView _american;
    public ObservableCollection<Country> Countries {
        get {
            if (_countries == null) {
                _countries = new ObservableCollection<Country>();
            }
            return _countries;
        }
    }
    public ICollectionView European {
        get {
            if (_european == null) {
                _european = new CollectionViewSource {
                    Source = this.Countries
                }.View;
                _european.Filter += (e) => {
                    Country c = e as Country;
                    if (c.Name == "UK" || c.Name == "Ireland" || c.Name == "France") {
                        return true;
                    }
                    return false;
                };
            }
            return _european;
        }
    }
    public ICollectionView American {
        get {
            if (_american == null) {
                _american = new CollectionViewSource {
                    Source = this.Countries
                }.View;
                _american.Filter += (e) => {
                    Country c = e as Country;
                    if (c.Name == "USA" || c.Name == "Canada" || c.Name == "Mexico") {
                        return true;
                    }
                    return false;
                };
            }
            return _american;
        }
    }
