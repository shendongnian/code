    var groups = testList.GroupBy(item=> item.stock);
    foreach (var group in groups) // get the individual groups
    {
      Console.Write(group.Key); // Will print "StocksFR1:" etc
      // well, I wont pretty print, up to you :)
      foreach (var item in group)
      {
        Console.Write(item.price); // Will print the price
      }
      Console.WriteLine();
    }
