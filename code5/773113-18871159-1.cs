    string filterFromDateStr = "2013-07-01T00:00:00Z";
    
    //Just the date since we don't want to use the Time
    var filterFromDate = DateTime.Parse(filterFromDateStr ).Date;
    
    sQry += " AND c.Close_Date__c > @filterFromDate AND c.Close_Date__c < @filterFromDate";
    
    IDbCommand cmd = connection.CreateCommand();
    cmd.CommandTimeout = connection.ConnectionTimeout;
    cmd.CommandText = sQuery;
    
    cmd.Parameters.Add(new SqlParameter("@filterFromDate ",filterFromDate ));
    
    md.Connection = connection;
    var reader = cmd.ExecuteReader();
