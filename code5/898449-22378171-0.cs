    var myEntity = DatabaseFunctions.DatabaseClient
        .tbl_MeterLoadProfile
        .OrderByDescending(a => a.MeterReadDate)
        .FirstOrDefault(a => a.MeterID == meterID);
    if(myEntity != null) {
        var properties = myEntity.GetType().GetProperties();
        // iterate through the list of public properties or query to find the one you want
    }
