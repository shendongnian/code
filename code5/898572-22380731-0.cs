            DataTable dt = new DataTable();
            SqlConnection InsertCon = new SqlConnection();
            InsertCon.ConnectionString = Connection_String;
            InsertCon.Open();
             
            try  
            {     
                SqlCommand com = new SqlCommand("Sql Query");
                com.Connection = InsertCon;
                com.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(dt);
                 
                 dataGridView1.DataSource = dt;
             
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
            finally
            {
                InsertCon.Close();
            }
