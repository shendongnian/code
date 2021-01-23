        var massiveModel = new DynamicModel(dbConn.ConnectionString);
        var connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=TEST;User ID=as;Password=;Application Name=BRUCE_WAYNE");
            connection.Open();
        var massiveConnection = connection;
        var tmp = massiveModel.Query("exec MY_SP 4412 '20131016' ", MassiveConnection).ToList();
