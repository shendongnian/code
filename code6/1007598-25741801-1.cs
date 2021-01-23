    private List<string> _myList; 
    public List<string> MyList
    {
       get { _myList.Sort(); return _myList; }
       set { _myList = value; }
    }
