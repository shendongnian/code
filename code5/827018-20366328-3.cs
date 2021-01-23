    public UserAvatar() 
    {
        Id(x => x.ID);
        HasOne(x => x.User)
          .Constrained()
          .ForeignKey();
        ...
    public UserMapping() 
    {
        Id(x => x.ID);
        HasOne(s => s.Avatar).Cascade.All();
    
