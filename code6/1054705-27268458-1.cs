    public void Save(IItem item, List<IItem> list)
    {
        
        if (list.Find(x => x.Name == item.Name) == null)
           list.Add(item);
    }
