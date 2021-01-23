    using(OleDbConnection con = new OleDbConnection(connParam))
    using(OleDbCommand cmd = new OleDbCommand("select count(*) from data where Users = ?"))
    {
         con.Open();    
         cmd.Connection = con;              
         cmd.Parameters.AddWithValue("@UserName", textBox1.Text);       
         
         if(cmd.ExecuteScalar() == null)
         {
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO data (Users,Pass) values(?, ?);";
            cmd.Parameters.AddWithValue("@Users", textBox1.Text);
            cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registration Success!");
         }
         else
           errorProvider2.SetError(textBox1, "This username has been using by another user.");
    }
