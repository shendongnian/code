    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string strcmd = "INSERT INTO student VALUES(@name,@rollno)";
            using (OleDbConnection MyConn = new OleDbConnection("connectionstring"))
            {
                using (OleDbCommand cmd = new OleDbCommand(strcmd, MyConn))
                {
                    cmd.Parameters.AddWithValue("@name", txtsname.Text);
                    cmd.Parameters.AddWithValue("@rollno", int.Parse(txtslrollno.Text));
                    if (MyConn.State == ConnectionState.Closed) { MyConn.Open(); }
                    cmd.ExecuteNonQuery();
                    if (MyConn.State == ConnectionState.Open) { MyConn.Close(); }
                    showData();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
