    List<dynamic> lstOrders = new List<dynamic>();
    lstOrders.Add(new { CustID = 1, Item = "Soap" });
    lstOrders.Add(new { CustID = 1, Item = "Brush" });
    lstOrders.Add(new { CustID = 2, Item = "Brush" });
    lstOrders.Add(new { CustID = 2, Item = "Toothpaste" });
    lstOrders.Add(new { CustID = 2, Item = "Razor" });
    lstOrders.Add(new { CustID = 2, Item = "Razor Blades" });
    lstOrders.Add(new { CustID = 3, Item = "Razor" });
    lstOrders.Add(new { CustID = 3, Item = "Razor Blades" });
    
    var items = lstOrders.Select(x => x.Item).Distinct();
    
    var orders = lstOrders.SelectMany((value, index) => lstOrders.Skip(index + 1),
                                               (first, second) => new { Item1 = first, Item2 = second }).Where(x => x.Item1.CustID == x.Item2.CustID);
    
    var combinations = from r in orders
                       select new { CustID = r.Item1.CustID, Combination = new { Item1 = r.Item1.Item, Item2 = r.Item2.Item } };
    
    var group = combinations.GroupBy(x => x.Combination);
    
    foreach (var grpItem in group)
      {
        Console.WriteLine(string.Format("Item combination {{{0}, {1}}} has been purchased by {2} customer(s).", grpItem.Key.Item1, grpItem.Key.Item2, grpItem.Count()));
      }
    Console.Read();
