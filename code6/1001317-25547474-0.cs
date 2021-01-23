    private ObservableCollection<Resultat> _resultatCollection;
    public ObservableCollection<Resultat> ResultatCollection
    {
    	get { return _resultatCollection; }
    	set
    	{
    		if (value == _resultatCollection) return;
    		_resultatCollection = value;
    		RaisePropertyChanged(() => ResultatCollection);
    	}
    }
