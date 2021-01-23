    private string _name;
    public string Name
    {
       get { return _name; }
    }
    {
        set 
        {
            _name = value;
            OnPropertyChanged();
            OnPropertyChanged("Item");
        }
    }
    private MyType item;
    public MyType Item
    {
        get { return item; }
        set {
              if(item == null)
                return;
              item = value;
              OnPropertyChanged(()=>Item);
            }
    }
