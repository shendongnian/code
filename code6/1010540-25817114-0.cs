    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd1 = new SqlCommand("select 1 from Table where Name =@UserName", con),
            cmd2 = new SqlCommand("select 1 from Table where Email=@UserEmail", con);
            con.Open();
            cmd1.Parameters.AddWithValue("@UserName", Name_id.Text);
            cmd2.Parameters.AddWithValue("@UserEmail", Email_id.Text);
            bool userExists = false, mailExists = false;
            using (var dr1 = cmd1.ExecuteReader())
                if (userExists = dr1.HasRows) Label1.Text = "user name already exists";
            using (var dr2 = cmd2.ExecuteReader())
                if (mailExists = dr2.HasRows) Label1.Text = "email already exists";
            if (!(userExists || mailExists))
            {
                //add User
            }
