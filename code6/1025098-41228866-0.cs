            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers(Id,Name,Country,) values (@Id,@Name,@Country)",con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id",dataGridView1.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@Name",dataGridView1.Rows[i].Cells[1].Value);
                cmd.Parameters.AddWithValue("@Country",dataGridView1.Rows[i].Cells[2].Value);
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
                MessageBox.Show("Added successfully!");
            
        }
