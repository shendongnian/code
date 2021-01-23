    IQueryable<TCPDriverMapping> query =
        dbContext.TCPDriverMappings.Where(c => c.DriverFacilityId == "abc" &&
                                               c.DriverValue == "0");
    if(controlledParamId == null)
        query = query.Where(c => c.DriverControlledParameterId == null);
    else
        query = query.Where(c => c.DriverControlledParameterId == controlledParamId);
    var test = query.FirstOrDefault();
