    public void Save(IItem item, List<IItem> list)
    {
        
        if (!list.Any(x => x.Name == item.Name))
           list.Add(item);
    }
