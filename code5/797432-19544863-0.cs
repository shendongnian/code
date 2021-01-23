    public object GroupedItems {
      get {
        if (this.Items != null)
        {
            return Items.OrderBy(item=>item.Name)
                        .GroupBy(item=>item.FirstLetter)
                        .OrderBy(g=>g.Key)
                        .Select(g=> new {
                                   FirstLetter = g.Key,
                                   Items = g.ToList()
                                }).ToList();
        }
        else  {
            return null;
        }
      }
      private set { }
    }
