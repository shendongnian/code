        SqlConnection con = new SqlConnection(@"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=Asig;Integrated Security=True;");
    SqlCommand cmd;
    
    .................
    
    con.Open();
    cmd = new SqlCommand("INSERT INTO asigpag( Data1,Data2,Data3 ) VALUES ('" + string.IsNullOrEmpt(txtBox1.Text) ? null :txtBox1.Text  + "','"  + string.IsNullOrEmpty(txtBox2.Text) ? null :txtBox2.Text  + "','" + string.IsNullOrEmpty(txtBox3.Text) ? null :txtBox3.Text + "')",con);
    
    cmd.ExecuteNonQuery();
    MessageBox.Show("Succes ! ");
