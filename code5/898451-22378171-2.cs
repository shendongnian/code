    var myEntity = DatabaseFunctions.DatabaseClient
        .tbl_MeterLoadProfile
        .OrderByDescending(a => a.MeterReadDate)
        .FirstOrDefault(a => a.MeterID == meterID);
    if(myEntity != null) {
        var properties = myEntity.GetType().GetProperties();
        // iterate through the list of public properties or query to find the one you want
        // for this example I will just get the first property, and use it to get the value:
        var firstProperty = properties.FirstOrDefault();
        // get the value, it will be an object so you might need to cast it
        object value = firstProperty.GetValue(myEntity);
    }
