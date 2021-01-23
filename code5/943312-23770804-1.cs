    public List<Teachers> GetTeachers()
    {
        return GetEligibleTeachers(x => x.fieldname);
    }
    
    public List<Teachers> GetEligibleTeachers(Func<Teachers, bool> elementIdentity)
    {
       var query = Context.Teachers.Where(elementIdentity == true) // rest of query
    }
