    dynamic parameters = new {
    
    };
    
    if (!string.IsNullOrWhiteSpace(startDate)) 
    {
       parameters.StartDate = startDate;
    }
    
    connection.Query<MyObject>("[dbo].[sp_MyStoredProcedure]"), parameters, commandType: CommandType.StoredProcedure);
