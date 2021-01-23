    DataTable dt = new DataTable();
    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    using (var cmd = new SqlCommand(" SELECT FName" +
                                            " FROM EmployeeTable " +
                                            " WHERE EmployeeId = @empId",
                                            con))
    {
        cmd.Parameters.Add(new SqlParameter("@empId",empId));
        try
        {
               con.open();
               dt.Load(cmd.ExecuteReader());
        }
        catch(Exception) //BAD BAD BAD!!! Why are you doing this!
        {
        }
    }
    return dt;
