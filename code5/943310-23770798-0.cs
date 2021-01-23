    public List<Teachers> GetEligibleTeachers(Func<Teachers, bool> predicate)
    {
      var query = this.Context.Teachers.Where(predicate);
     // .... rest of the query
    }
