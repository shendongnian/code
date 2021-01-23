    #region Get the value from db
            using (SqlConnection c = new SqlConnection(connect))
            {
                c.Open();
                using (SqlCommand cm = new SqlCommand(com,c))
                {
                    cm.Parameters.AddWithValue("@nickname", nick);
                    SqlDataReader s = null;
                    s = cm.ExecuteReader();
                    while (s.Read())
                    {
                        string oras = Convert.ToString(s["Oras"]);
                        string judet = Convert.ToString(s["judet"]);
                        string adresa = Convert.ToString(s["adresa"]);
                        textBox1.Text = oras;
                        textBox2.Text = judet;
                        textBox3.Text = adresa;
                    }
                }
                c.Close();
    
            }
            #endregion
        
