    public void Save(IItem item, List<IItem> list)
    {
        bool itemFound = false;
        foreach (var _item in list)
        {
            if (_item.Name == item.Name)
            {
                itemFound = true;
                break;
            }
        }
        if (!itemFound)
           list.Add(item);
    }
