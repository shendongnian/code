        protected void Button1_Click(object sender, EventArgs e)
        {
            //TODO: Ask Stackoverflow how to get these values from browser-land javascript
            Double latitude = Convert.ToDouble(lat.Value);
            Double longitude = Convert.ToDouble(lng.Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "@Data Source=(LocalDB)\v11.0;AttachDbFilename=Database.mdf;Integrated Security=True";
            string query1 = "insert into Courses(longi,lati) values (@lati, @longi)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@lati", latitude);
            cmd1.Parameters.AddWithValue("@longi", longitude);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
 
