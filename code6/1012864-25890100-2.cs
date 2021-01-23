    public ApproverType Replaces
    {
     get
     {
      return ReplacesWorkaround.SingleOrDefault();
     }
     set
     {
      ReplacesWorkaround.RemoveAll();
      ReplacesWorkaround.Add(value);
     }
    }
