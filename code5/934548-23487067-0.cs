    private int distance = 0;
    public int Distance
    {
       get { return distance;}
       set { distance = value; OnPropertyChanged("DistanceTxt"); }
    }
    public string DistanceTxt
    {
       get { return distance.ToString() + " meter"; }
    }
