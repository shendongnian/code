    private List<A> allGroupsHolder = null;
    public IEnumerable<tableType> GetAllObjects<tableType>() where tableType : class
    {
        if (typeof(tableType) == typeof(Group))
        {
            if (groupHolderState)
            {
                groupHolderState = true;
                var t = db.GetTable<Group>();
                allGroupsHolder = t.ToList();
            }
            return allGroupsHolder.Cast<tableType>();
        }
        var table = db.GetTable<tableType>();
        return table.ToList();
    }
