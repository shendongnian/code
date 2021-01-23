    var newlist = listOrder.ToList().GetRange(jtStartIndex, jtPageSize);
    if(!string.IsNullOrWhiteSpace(sorting))
    {
      newlist = newlist.OrderByDescending(o => o.Date).ToList();
    }
