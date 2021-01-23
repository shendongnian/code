    var itemsToRemove = new List<Receipts>();
    
    foreach (var item in _invoice.Receipts)
    {
       if(condition)
       {
           itemsToRemove.Add(item);
       }
    }
