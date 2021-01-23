    public string GetHierarchicalSortOrder(HierarchyTable element)
    {
       List<int> sortOrders = new List<int>(element.SortOrder);
       
       while (element.Parent != null)
       {
          element = element.Parent;
          sortOrders.Insert(0, element);
       }
       return String.Join(",", sortOrders);
    }
