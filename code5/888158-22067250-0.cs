    protected void btnSaveData_Click(object sender, EventArgs e)
    {
    MySqlConnection con = new MySqlConnection("connection string here");
    String query="INSERT INTO [TABLENAME]  
             ([COLUMNNAME1],[COLUMNNAME2]) VALUES(@COLUMNVALUE1 , @COLUMNVALUE2)";
    MySqlCommand command = new MySqlCommand(query,con);
    command.Parameters.AddWithValue("@COLUMNNAME1",textBox1.Text);
    command.Parameters.AddWithValue("@COLUMNNAME2",textBox2.Text);
    int status=0;
    con.Open();
    status = command.ExecuteNonQuery();
    if(status>0)
    {
    MessageBox.Show("Rows Inserted Successfully!");
    }
    else
    {
    MessageBox.Show("No Rows Inserted!");
    }
    con.Close();
    }
