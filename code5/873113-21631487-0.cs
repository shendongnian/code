    dynamic parameters = new {
    
    };
    
    if (!string.IsNullOrWhitespace(startDate)) 
    {
       parameters.StartDate = startDate;
    }
    
    connection.Query<MyObject>("[dbo].[sp_MyStoredProcedure]"), parameters, commandType: CommandType.StoredProcedure);
