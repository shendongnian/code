    string qr1 = "select companyname from table1";
            SqlCommand cmd1 = new SqlCommand(qr1, con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            cmbcat.Items.Clear();
            while (dr1.Read())
            {
                cmbcat.Items.Add(dr1[0].ToString());
    
            }
            con.Close();
