    using ServiceStack.OrmLite.Dapper;
    using (var db = new SqlConnection(@"Data Source=... etc."))
    {
        db.Open();
    
        var p = new DynamicParameters();
        p.Add("@params", "Id=21");
    
        IEnumerable<dynamic> dynamicResults = db.Query(sql:"GetPivotData", param: p,
            commandType:CommandType.StoredProcedure);
    }
