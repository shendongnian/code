    private string _name;
    public string Name
    {
       get { return _name; }
       set 
       {
          _name = value;
          PropertyChanged("Name");
       }
    }
     
    private void PropertyChanged(string prop)
    {
       if( PropertyChanged != null )
       {
          PropertyChanged(this, new PropertyChangedEventArgs(prop);
       }
    }
