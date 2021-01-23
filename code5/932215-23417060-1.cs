    private bool IsDuplicate(RoleGroup r)
    {
        using (var business = new RoleGroupBusiness())
        {
            return business.Any(x => x.RoleID == r.RoleID &&
                                 x.ComponentGroupID == r.ComponentGroupID &&
                                 x.OperationID == r.OperationID);
        }
    }
