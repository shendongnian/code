    var statusFromSomeFunkyEntity = GetStatusFromSomeFunkyEntity();
    var query =
        from i in this.DbContext.MyFunkyEntities.AsExpandable()
        select new SomeFunkyEntityWithStatus()
        {
            FunkyEntity = i,
            Status = statusFromSomeFunkyEntity.Invoke(i)
        };
