        String Usercheck = "IF Exist( Select Benutzername from UserLogin where Benutzername='" + tb_name.Text + "'");
        SqlCommand cmd = new SqlCommand(Usercheck, conn);
        
    bool temp = ;
        if (temp)
        {
            Response.Write("User already exists");
        }
        conn.Close();
