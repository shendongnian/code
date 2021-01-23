    var UnitPriceIndex = new SortedDictionary<double, LinkedList<OrderItem>>();
            
    foreach (OrderItem item in Data)
    {
        // Make sure the key exists. If it doesn't, add it 
        // along with a new LinkedList<OrderItem> as the value
        if (!UnitPriceIndex.ContainsKey(item.UnitPrice))
        {
            UnitPriceIndex.Add(item.UnitPrice, new LinkedList<OrderItem>());
        }
        UnitPriceIndex[item.UnitPrice].AddLast(item);
    }
