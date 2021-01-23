    private List<ObjectA> _ObjectAList; //private backing field
    public List<ObjectA> ObjectAList
    {
        get
        {
            return _ObjectAList ?? new List<ObjectA>();
        }
        set
        {
            _ObjectAList = value;
        }
    }
