    con.Open();               
    ad.InsertCommand = new OleDbCommand("INSERT INTO UserInfo values(@Birth_month, @Firstname, @Surname, @ID", con);   
    ad.InsertCommand.Parameters.Add("@Birth_month", OleDbType.Numeric).Value = int.Parse(textBox1.Text);
    ad.InsertCommand.Parameters.Add("@Firstname", OleDbType.VarChar).Value = textBox2.Text.ToString();
    ad.InsertCommand.Parameters.Add("@Surname", OleDbType.VarChar).Value = textBox3.Text.ToString();
    ad.InsertCommand.Parameters.Add("@ID", OleDbType.Numeric).Value = int.Parse(textBox4.Text);
    ad.InsertCommand.ExecuteNonQuery();
    con.Close();
