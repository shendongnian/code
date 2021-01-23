    private Parts _selectedPart;
    public Parts SelectedPart
    {
        get{return _selectedPart;}
        set{
            _selectedPart= value;
            SelectedProducer = _selectedPart.Producer;
            OnPropertyChanged("SelectedPart");
        }
    }
    
    private Producers _selectedProducer;
    public  Producers SelectedProducer 
    {
        get{return _selectedProducer; }
        set
        {  _selectedProducer= value;
    
            OnPropertyChanged("SelectedProducer");
        }
    }
