    private string _name;
    public string Name 
    {
        get
        {
            return _name;
        }
        set
        {
            if ( value != _name )
            {
               //business logic here
            }
            _name = value;
        }
    } 
