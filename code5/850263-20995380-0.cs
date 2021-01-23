     public static List<Product> Collapse(List<Product> ExpandedList)
     {
     List<Product> CollapsedList = new List<Product>();
     var groupBy = ExpandedList.GroupBy(x => x.Id);
     foreach (var group in groupBy)
     {
      var first = group.FirstOrDefault();
      first.Quantity = group.Sum(x => x.Quantity);
      CollapsedList.Add(first);
     }
     return CollapsedList;
     }
