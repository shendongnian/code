    System.Data.SqlTypes.SqlDateTime entry2 = new System.Data.SqlTypes.SqlDateTime(new DateTime(dto.LookUpDateTime));
    DateTime entry = entry2.Value;
    
    var existticket = from db in context.Tickets
                                  where db.LookupDateTime == entry && db.UserId == UserId
                                  select db;
