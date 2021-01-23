    using (var dr1 = cmd1.ExecuteReader())
    {
        if (dr1.HasRows)
        {
            string Text = "user name already exists";
        }
        dr1.Close();
    }
    using (var dr2 = cmd2.ExecuteReader())
    {
        if (dr2.HasRows)
        {
            string ext = "email already exists";
        }
        else
        {
            //add new users
        }
        dr2.Close();
    }
    con.Close();
