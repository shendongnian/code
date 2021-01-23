    using(OleDbConnection con = new OleDbConnection(connParam))
    using(OleDbCommand cmd = new OleDbCommand("select count(*) from data where Users = ?"))
    {
         con.Open();    
         cmd.Connection = con;              
         cmd.Parameters.AddWithValue("@UserName", textBox1.Text);        
         object objRes = cmd.ExecuteScalar();
         
         if (objRes == null || (int)objRes == 0)
         {
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO data (Users,Pass) values(?, ?);";
            cmd.Parameters.AddWithValue("@Users", textBox1.Text);
            cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
            int iRes = cmd.ExecuteNonQuery();
            if(iRes > 0)
                MessageBox.Show("Registration Success!");
         }
         else
           errorProvider2.SetError(textBox1, "This username has been using by another user.");
    }
