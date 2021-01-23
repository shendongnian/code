    private List<GroupByDateType> _GroupByItems;
    public List<GroupByDateType> GroupByItems
    {
        get { return _GroupByItems ?? (_GroupByItems = Enum.GetValues(typeof(GroupByDateType)).Cast<GroupByDateType>().ToList()); }
    }
    public List<GroupByDateType> GroupByItems2
    {
        get { return Enum.GetValues(typeof(GroupByDateType)).Cast<GroupByDateType>().ToList(); }
    }
