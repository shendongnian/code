    public int ManageUser(string staffID, String Name, ......)
    {
    try
    {
        int Staffid = getstaffid();
        int result = 0;
        SqlCommand cmd = new SqlCommand("sp_ManageUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@StaffID",Staffid);
        cmd.Parameters.AddWithValue("@Name", Name);
        ....
    }
