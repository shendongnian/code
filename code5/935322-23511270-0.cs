    ListType? _listType;
    public ListType? List
    {
        get
        { 
            return _listType;
        }
        set
        {
            if (Enum.IsDefined(typeof(ListType),value))
                _listType=value;
            else
                _listType=null;
        }
    }
      
