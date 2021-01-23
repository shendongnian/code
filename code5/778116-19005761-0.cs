    TCPDriverMapping test;
    if(controlledParamId == null)
        test = dbContext.TCPDriverMappings.FirstOrDefault(
                              c => c.DriverFacilityId == "abc" &&
                                         c.DriverControlledParameterId == null &&
                                         c.DriverValue == "0");
    else 
        test = dbContext.TCPDriverMappings.FirstOrDefault(
                              c => c.DriverFacilityId == "abc" &&
                                         c.DriverControlledParameterId == controlledParamId &&
                                         c.DriverValue == "0");
