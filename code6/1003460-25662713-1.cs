    public UserMapping()
    {
        ...
        References(x => x.UserAdditionalData)
              .LazyLoad()
              .PropertyRef(e => e.UserId)
              .Not.Insert()
              .Not.Update()
              ;
    }
