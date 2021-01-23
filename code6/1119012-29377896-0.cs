    var sql = "SomeSchema.SomeTableInsert @Id, @SomeData, @UserId";
    var sqlParameters = new List<SqlParameter> 
    { 
        new SqlParameter("Id", 1),
        new SqlParameter("SomeData", "This is some random data"), 
        new SqlParameter("UserId", 500)
    };
    dbContext.Database.ExecuteSqlCommand(sql, sqlParameters.ToArray<object>());
