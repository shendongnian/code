    foreach (var item in itemSet)
    {
      if (item.ItemID == itemToCompareTo.ItemID)
      {
        itemSet.Remove(item);
        break;
      }
    }
