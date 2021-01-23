    var fnRac = new OracleCommand();
    fnRac.Connection = conn;
    fnRac.CommandText = "web_shop_interface.kreiraj_mp_racun";
    fnRac.CommandType = CommandType.StoredProcedure;
    
    var ret = new OracleParameter("ret", OracleDbType.Varchar2);
    ret.Direction = ParameterDirection.ReturnValue;
    ret.Size = 4096;
    fnRac.Parameters.Add(ret);
    
    var p1 = new OracleParameter("did", OracleDbType.Decimal);
    p1.Value = 15m;
    p1.Direction = ParameterDirection.Input;
    fnRac.Parameters.Add(p1);
    
    var p2 = new OracleParameter("prn", OracleDbType.Varchar2);
    p2.Value = "Invoice 15";
    p2.Direction = ParameterDirection.Input;
    fnRac.Parameters.Add(p2);
    
    fnRac.ExecuteNonQuery();
