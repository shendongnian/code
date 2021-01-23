    using Dapper;
    
    using (var connection = MyConnectionFactory.GetConnection()) {
        connection.Open();
        var data = cnn.Query<MyPocoObject>(
            "spMySp",
            new { MyParameter = 1 }, 
            commandType: CommandType.StoredProcedure
        );
        return data;
    }
