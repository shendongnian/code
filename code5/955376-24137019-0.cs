     try
            {
    
                string date1=textBox1.Text;
                string date2= textBox2.Text;
                if (date1!=null)&&((date2!=null)
               {
                date1=DateTime.TryParse(date1).ToString("yyyy/MM/dd HH:mm:ss.fff");
                date2=DateTime.TryParse(date2).ToString("yyyy/MM/dd HH:mm:ss.fff");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Scout_DHQ_Manager.Properties.Settings.Default.constring;
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("INSERT INTO Table1 (dt,dt2) VALUES(@dt1,@dt2)", con);
                cmd.Parameters.AddWithValue("@dt1", date1);
                cmd.Parameters.AddWithValue("@dt2", date2);
                cmd.ExecuteNonQuery();         
                con.Close();
             }
    
            }
            else
            {
              MessageBox.Show("Please Fill in both Textboxes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erroe Occure in Connection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
