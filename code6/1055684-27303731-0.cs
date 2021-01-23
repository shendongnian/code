    public int getstaffid()
    { 
    int staffid = 0;
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    string query = " Select StaffID from tbl_Staff where Name=@Name and Username = @Username";
    cmd.CommandText = query;
    SqlParameter param = new SqlParameter("@Name", txtFullName.Text);
    cmd.Parameters.Add(param);
    SqlParameter param = new SqlParameter("@Username", txtUserame.Text);
    cmd.Parameters.Add(param);
     try
    {
        con.Open();
        staffid= cmd.ExecuteNonQuery();     
        return staffid;       
    }
    catch (Exception ex)
    {
        throw;
    }
    }
