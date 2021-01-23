    private Term _term;
    public Term NewTerm{
        get{return _term;}
        set
        {
           _term= value;
           OnPropertyChanged("Term");
        }
    }
