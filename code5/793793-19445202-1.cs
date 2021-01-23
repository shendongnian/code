        if(i<=count)
    {
         string cmdstr = "select * from table where id = " + i;
           OleDbConnection con = new OleDbConnection(constr);
           OleDbCommand com = new OleDbCommand(cmdstr, con);
           con.Open();
           OleDbDataReader reader = com.ExecuteReader();
           reader.Read();
           label1.Text = String.Format("{0}", reader[1]);
           RadioButton1.Text = String.Format("{0}", reader[2]);
           RadioButton2.Text = String.Format("{0}", reader[3]);
           RadioButton3.Text = String.Format("{0}", reader[4]);
           RadioButton4.Text = String.Format("{0}", reader[5]);
           con.Close();
           i++;     
    }
