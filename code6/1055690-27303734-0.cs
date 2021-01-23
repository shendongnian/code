    uc.ManageUser(txtStaffID.Text, txtFullName.Text, .......
    ....
    public int ManageUser(string staffID, String Name, ......)
    {
        try
        {
            int result = 0;
            SqlCommand cmd = new SqlCommand("sp_ManageUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffID", Convert.ToInt32(staffID));
            cmd.Parameters.AddWithValue("@Name", Name);
            ....
    }
