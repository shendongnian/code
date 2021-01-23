        using (var dr1 = cmd1.ExecuteReader())
        {
            if (dr1.HasRows)
            {
                Label1.Text = "user name already exists";
                dr1.Close();
            }
            using (var dr2 = cmd2.ExecuteReader())
            {
                if (dr2.HasRows)
                {
                    Label1.Text = "email already exists";
                    dr2.Close();
                }
                else
                {
                    dr1.Close();
                    dr2.Close();
                    //add new users
                    con.Close();
                }
            }
        }
