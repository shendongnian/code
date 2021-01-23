            SqlConnection con = new SqlConnection("Data Source=xxxxx;Initial Catalog=yyyyy;Integrated Security=true;");
            SqlCommand cmnd = con.CreateCommand();
            
            cmnd.CommandText = "Select * from BillingType";
            con.Open();
            SqlDataReader rd = cmnd.ExecuteReader();
            while (rd.Read())
                {
                    string someFieldText = rd[1].ToString();
                    comboBox1.Items.Add(someFieldText);
                }
            }
            con.Close();
