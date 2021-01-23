    private YourItemType _mySelectedItem;
    public YourItemType MySelectedItem
    {
     get { return (_mySelectedItem);}
    set
    {
    if (_mySelectedItem != value)
    {
     _mySelectedItem = value;
    if (PropertyChanged != null)
       PropertyChanged(this, new PropertyChangedEventArgs("MySelectedItem"));
    }
    }
