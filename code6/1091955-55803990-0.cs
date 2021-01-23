    newParam = new    OracleParameter("Response",OracleType.VarChar);
    Use **OracleType.Char** instead of     **OracleType.VarChar** 
    newParam = new    OracleParameter("Response", OracleType.Char);
     IT works in my case.
    I am using Oracle 11g and  VS12 ,truncating output parameter in dot net code, 
    even i changed the output parameter as integer in Stored procedure.
    When i changed to Char instead of Varchar  as below in dot net it works Fine.
    db.AddParameter(dbCommand, "p_out_result", OracleType.Char, 300, 
    ParameterDirection.Output, true, 100, 3, null, DataRowVersion.Default, null);
