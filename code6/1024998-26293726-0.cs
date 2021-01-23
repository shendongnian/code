    public static int UpdateEmployee(int id, string name, string gender, string city)
    {
        string connection = "Data Source=SRM-318;Initial Catalog=employee;User ID=sa;Password=****";
    
        SqlConnection scon = new SqlConnection(connection);
    
        string updateQuery = "update emp SET name=@name, gender=@gender, city=@city WHERE id=@id";
        SqlCommand scmd = new SqlCommand(updateQuery, scon);
    
        scmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        scmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
        scmd.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
        scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        scon.Open();
        return scmd.ExecuteNonQuery();
    }
