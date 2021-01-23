    private ClientSurveyor selectedclientrep;
    public ClientSurveyor SelectedClientRep
    {
        get { return selectedclientrep; }
        set
        {
            selectedclientrep = value;
            OnPropertyChanged("SelectedClientRep");
        }
    }
