    string[] splittedText1 = textBox2.Text.Split(' ');
    string[] splittedText2 = textBox1.Text.Split(' ');
    string[] splittedText3 = textBox3.Text.Split(' ');
    string _sql = "Insert into [sales] ([productname], productquantity, productprice) VALUES ('{0}', {1}, {2})";
    OleDbCommand CmdSql = new OleDbCommand();
    CmdSql.Connection = Cnn;
    
    for (int i = 0; i < splittedText1.Length; i++)
    {
    	CmdSql.CommandText = String.Format(_sql, splittedText1[i], splittedText2[2], splittedText3[i]);
    	CmdSql.ExecuteNonQuery();
    }
