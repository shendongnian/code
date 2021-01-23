    public IEnumerable<MenuGroupItem> MenuGroupItems { get; set; }
    public void AddMenuItem(MenuGroupItem menuGroupItem)
    {
        MenuGroupItems.Add(menuGroupItem);
    }
