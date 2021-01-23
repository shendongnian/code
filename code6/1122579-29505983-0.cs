            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["socailweb"].ConnectionString);
            string sql = "select * from tblUsers  where remail='" + Session["remail2"] + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            if (sqldr.Read() == true)
            {
                lblVotersID.Text = sqldr.GetValue(2).ToString();
                lblVoterName.Text = sqldr.GetValue(3).ToString();
               
            }
            sqldr.Close();
            con.Close();
