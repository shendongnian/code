     public virtual List<Jobs> uspGetJobs(string startDate)
     {
        var startDateParameter = startDate != null ?
                                 new SqlParameter("startDate", startDate) :
                                 new SqlParameter("startDate", typeof(string));
    
        return this.Database.SqlQuery<PlannedJobs>("uspGetPlannedJobs @startDate, @locationCode", startDateParameter, locationCodeParameter).ToList();
     }
