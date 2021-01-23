            SqlConnection cn = new SqlConnection(global::dotasuka.Properties.Settings.Default.Database1ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Heroes (heroname,attacktype,patribute,role,role2,role3) Values (@heroname,@attacktype,@patribute,@role,@role2,@role3) ", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("@heroname", textBox1.Text);
                cmd.Parameters.AddWithValue("@attacktype", textBox2.Text);
                cmd.Parameters.AddWithValue("@patribute", textBox3.Text);
                cmd.Parameters.AddWithValue("@role", textBox4.Text);
                cmd.Parameters.AddWithValue("@role2", textBox5.Text);
                cmd.Parameters.AddWithValue("@role3", textBox6.Text);
                cmd.ExecuteNonQuery();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
