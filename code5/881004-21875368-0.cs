    dynamicParams.Add("rval", dbType: DbType.Int32,
        direction: ParameterDirection.ReturnValue);
    dynamicParams.Add("NEWNUMBER", dbType: DbType.String,
        direction: ParameterDirection.Output, size: 100);
    db.Execute("GetNextNumberTest", dynamicParams,
        commandType: CommandType.StoredProcedure);
    var rval = dynamicParams.Get<int>("rval");
    var result = dynamicParams.Get<string>("NEWNUMBER");
