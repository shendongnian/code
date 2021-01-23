    public void Filter(type filterType)
    {
        MenuItems.Clear();
        foreach(var item in AllItems)
        {
           if(item.type == filterType)
           {
              MenuItems.Add(item);
           }
        }
    }
