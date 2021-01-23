    var or = Expression.Parameter(typeof(ObjectReport));
    var cond1 = Expression.Equal(
        Expression.Property(or, "ReportingUserId"), 
        Expression.Constant(reportModel.ReportingUserId));
    var cond2 = Expression.Equal(
        Expression.Property(or, "Reported" + target + "Id"), 
        Expression.Constant(reportModel.GetPropertyValue("Reported" + target + "Id")));
    var cond3 = Expression.Equal(
        Expression.Call(
            typeof(DbFunctions), 
            "TruncateTime", 
            Type.EmptyTypes, 
            Expression.Convert(Expression.Property(or, "ReportDate"), typeof(DateTime?))),
        Expression.Convert(Expression.Constant(serverTimeToday), typeof(DateTime?)));
    var cond = Expression.AndAlso(Expression.AndAlso(cond1, cond2), cond3);
    var predicate = Expression.Lambda<Func<ObjectReport, bool>>(cond, or);
    int count = this.objectReportsRepository.All().Count(predicate);
