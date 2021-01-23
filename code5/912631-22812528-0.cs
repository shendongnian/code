    private List<object> MyList;
    private List<object> _subList;
    public List<object> SubSetOfList
    {
        get { return _subList ?? (_subList = MyList.Where(p => p.Property == SomeValue).ToList();) }
    }
