    public Add(Item item)
    {
      AddCore(item);
    }
    
    public Replace(Item item1, Item item2)
    {
      RemoveCore(item1);
      AddCore(item2);
    }
