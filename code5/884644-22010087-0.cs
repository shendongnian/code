    var param1 = new OracleParameter("personnel_Id_in", OracleDbType.VarChar, "c5eb5589-8fee-47b6-85ad-261a0307cc16",  ParameterDirection.Input);
    var param2 = new OracleParameter("base_date_in", OracleDbType.VarChar, "1112", ParameterDirection.Input);
    var param3 = new OracleParameter("is_current_in", OracleDbType.Number, 1, ParameterDirection.Input);
    var param4 = new OracleParameter("result", OracleDbType.Cursor, ParameterDirection.Output);
    var ATests =
    db.Database.SqlQuery<ATest>(
    "BEGIN PKG_TRAINING_SP.GETPERSONNELTRAINIGLIST(:personnel_Id_in, :base_date_in, :is_current_in, :result); end;", 
    param1,  param2, param3, param4).ToList();
