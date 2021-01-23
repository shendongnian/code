    private int _myField;
    
    public int getMyProperty()
    {
        return _myField;
    }
    
    public int setMyProperty(int value)
    {
        _myField = value;
    }
    
    int x = getMyProperty(); // Obviously cannot be marked as "out" or "ref"
