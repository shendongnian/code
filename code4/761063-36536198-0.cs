    // filter dates for test
    var startDate = DateTime.Parse("01/02/2016 12:00:00 AM"); 
    var endDate = DateTime.Parse("02/02/2016 12:00:00 AM");
    // Get the cloud table
    var cloudTable = GetCloudTable();
    // Create a query: in this example I use the DynamicTableEntity class
    var query = cloudTable.CreateQuery<DynamicTableEntity>()
            .Where(d => d.PartitionKey == "partition1"
                   && d.Timestamp >= startDate && d.Timestamp <= endDate);
    
    // Execute the query
    var result = query.ToList();
 
