    public void OrderLeaves()
    {
      children = children.Where(x => x.leaf).OrderBy(x => x.SortOrder).ToList();
     
      children.ToList().ForEach(c => c.OrderLeaves());
    }
