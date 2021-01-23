    private string mySelectedItem;
    public string MySelectedItem
    {
    get{return mySelectedItem;}
    set
    {
    mySelectedItem=value;
    RaisePropertyChanged("MySelectedItem");
    }
