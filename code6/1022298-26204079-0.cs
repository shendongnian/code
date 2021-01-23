         private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["cons"].ConnectionString.ToString());
            try
            {
                using (sqlcon)
                {
                    sqlcon.Open();
                    string str = "insert into tab(name,pwd) values(@Value1, @Value2)";
                    using (SqlCommand cmd = new SqlCommand(str, sqlcon))
                    {
                        cmd.Parameters.Add(new SqlParameter("Value1", TextBox1.Text));
                        cmd.Parameters.Add(new SqlParameter("Value2", TextBox2.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted");
                        //cmd.Clone(); 
                    }
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
