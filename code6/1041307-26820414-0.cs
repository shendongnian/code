    private int _pivotindex;
    public int PivotIndex{
        get{ return _pivotindex;}
        set{
             _pivotindex = value;
             NotifyOfPropertyChanged();
        }
    }
    public void SelectionChanged( SelectionChangedEventArgs e){
    }
