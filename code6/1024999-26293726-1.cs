    public static int UpdateEmployee(int id, string name, string gender, string city)
    {
        string connection = "Data Source=SRM-318;Initial Catalog=employee;User ID=sa;Password=****";
    
        SqlConnection scon = new SqlConnection(connection);
    
        string updateQuery = "update emp SET name=@pname, gender=@pgender, city=@pcity WHERE id=@pid";
        SqlCommand scmd = new SqlCommand(updateQuery, scon);
    
        scmd.CommandType = CommandType.Text;
        scmd.Parameters.Add("@pname", SqlDbType.VarChar).Value = name;
        scmd.Parameters.Add("@pgender", SqlDbType.VarChar).Value = gender;
        scmd.Parameters.Add("@pcity", SqlDbType.VarChar).Value = city;
        scmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;
        scon.Open();
        return scmd.ExecuteNonQuery();
    }
