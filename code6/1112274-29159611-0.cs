    private ApodModel _apod;
    public ApodModel Apod
    {
        get { return _apod; }
        set { _apod = value; 
              NotifyPropertyChange("Apod");
            }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChange(string name)
    {
        if(PropertyChanged!=null)
        {
            PropertyChanged(this,new PropertyChangedEventArgs(name));
        }
    }
