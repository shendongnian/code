    create procedure sp_authenticate
    (     @userId varchar(50),
          @pass varchar(50)  )
    as
    begin
    select user_id, password, status, role_id, email, contact_no, 
                    last_login_date, created_by, last_update_date, last_update_by
                    from users where user_id = @userid and password =@pass
    end
    //in C# code
   
    using (OracaleConnection con=new OracaleConnection())
    {
    conn.ConnectionString = connStr;
    conn.Open();
    using (OracleCommand cmd = new OracleCommand()) {
    cmd.Connection = conn;
    cmd.CommandText = "sp_authenticate";  //name of your procedure
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@userid", OracleType.VarChar,50).value=userID;
        cmd.Parameters.Add("@password", OracleType.VarChar,50).value=pwd;
    DataTable dt = new DataTable();
   
    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
     adapter.Fill(dt);
    if (dt.Rows.Count <= 0) {
    msg = "Invalid Login ID or Password"; }
    return dt; }
