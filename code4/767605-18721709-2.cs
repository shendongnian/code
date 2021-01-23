    public void Foo() {
        // do something here...
        var ungroupedUsers = GetTheUsers();
        var groupedUsers = ungroupedUsers.GroupBy(x=>x.Name.Substring(0,1))
        // and now use the groupedUsers accordingly
    }
