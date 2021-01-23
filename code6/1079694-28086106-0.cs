    Dictionary<string, List<ISortableObject>> Sort(List<ISortableObject> items)
    {
      var result = new Dictionary<string, List<ISortableObject>>();
      foreach(var item in items)
      {
        if (!result.ContainsKey(item.SortingKey))
        { result[item.SortingKey]=new List<ISortableObject>(); }
        result[item.SortingKey].Add(item);
      }
    }
