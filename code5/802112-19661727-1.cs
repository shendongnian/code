    // GET api/ItemList
    public IEnumerable<ItemOptionResult> GetItemOptions()
    {`enter code here`
        var itemoptions =
            db.ItemOptions
              .Select(i => 
               new ItemOptionResult
               { 
                   ItemOptionId = i.ItemOptionId, 
                   Active = i.Active, 
                   Name = i.Name 
               });
        return itemoptions.AsEnumerable();
    }
