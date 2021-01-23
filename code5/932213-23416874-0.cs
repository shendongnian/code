    private bool NotBeDuplicate(RoleGroup r, long dummy)
    {
      var business = new RoleGroupBusiness();
      var result = business.Where(x => x.RoleID == r.RoleID && x.ComponentGroupID == r.ComponentGroupID && x.OperationID == r.OperationID).Any();
      return !result;
    }
    public RoleGroupValidator()
    {
      RuleFor(x => x.RoleID).Must(NotBeDuplicate);
    }
