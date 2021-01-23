            string constring = ConfigurationManager.ConnectionStrings["ConnData"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("Select * from emailsignup where EmailId= @EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", this.textBox.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    MessageBox.Show("EmailId = " + dr[5].ToString() + " Already exist");
                    textBox.Clear();
                    break;
                }
            }
        }
