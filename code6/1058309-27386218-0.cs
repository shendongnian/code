    List<ListItem> parentList;
    public ListItem(List<ListItem> parentList)
    {
        this.parentList = parentList;
    }
    
    public override string ToString()
        { return parentList.IndexOf(this).ToString(); }
