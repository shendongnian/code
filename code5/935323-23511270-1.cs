    ListType? _listType;
    public ListType? List
    {
        get
        { 
            return _listType;
        }
        set
        {
            //Enumb.IsDefined doesn't like nulls
            if (value==null || Enum.IsDefined(typeof(ListType),value))
                _listType=value;
            else
                _listType=null;
        }
    }
      
