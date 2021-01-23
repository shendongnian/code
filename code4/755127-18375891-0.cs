    List<Item> before = new List<Item>();
    List<Item> after = new List<Item>();
    List<Item> between = new List<Item>();
    foreach (var item in Items)
    {
      if (item.CreatedDate <= timeBefore)
      {
        before.Add(item);
      }
      else if (item.CreatedDate >= timeAfter)
      {
        after.Add(item);
      }
      else
      {
        between.Add(item);
      }
    }
