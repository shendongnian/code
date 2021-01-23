    SqlConnection con = new SqlConnection(@"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=Asig;Integrated Security=True;");
    SqlCommand cmd;
    con.Open();
    cmd = new SqlCommand("INSERT INTO asigpag( Data1,Data2,Data3 ) VALUES ('@textBox1','@textBox1','@textBox1')",con);
    cmd.Parameters.AddWithValue("@textBox1", string.IsNullOrEmpty(txtBox1.Text) ? (object)DBNull.Value : txtBox1.Text);
    cmd.Parameters.AddWithValue("@textBox2", string.IsNullOrEmpty(txtBox2.Text) ? (object)DBNull.Value : txtBox2.Text);
    cmd.Parameters.AddWithValue("@textBox3", string.IsNullOrEmpty(txtBox3.Text) ? (object)DBNull.Value : txtBox3.Text);
    cmd.ExecuteNonQuery();
    MessageBox.Show("Succes ! ");
