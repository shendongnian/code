    using (SqlConnection cn = new SqlConnection(@"Persist Security Info=False;Integrated Security=true;Initial Catalog=testDB;server=(local)"))
    {           
                string sql = "INSERT INTO Test (TestInsert) Values('" + txtName.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added new record", "Message", MessageBoxButton.OK);
  
    }
