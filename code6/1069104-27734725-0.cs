    public void getData(string a) {
            SqlConnection conn = new SqlConnection(@"Data Source=MASSI\FABERSERVER;Initial Catalog=Data.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("Select UserID,UserName,Email FROM Login Where UserName= '" + a + "'", conn);
            SqlDataReader reader = command.ExecuteReader();
    
            string id, name, email;
    
            while (reader.Read())
            {
                id = reader["UserID"].ToString();
                name = reader["UserName"].ToString();
                email = reader["Email"].ToString();
    
            }
            conn.Close();
     
            label1.Text = id;
            label2.Text = name;
            label3.Text = email;
        }
    }
