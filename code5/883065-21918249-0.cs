      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            string strcmd = "INSERT INTO student (name, rollno) VALUES('" + txtsname.Text + "','" + Convert.ToInt32(txtsrollno.Text) + "')";
            cmd = new OleDbCommand(strcmd, MyConn);
            if (MyConn.State == ConnectionState.Closed) { MyConn.Open(); }
            cmd.ExecuteNonQuery();
            if (MyConn.State == ConnectionState.Open) { MyConn.Close(); }
            showData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        } 
     }
