    protected void btnSaveData_Click(object sender, EventArgs e)
    {
    //Read TextBox Values
    TextBox txBox1 = (TextBox) Controls.Find(controlNames[0])[0];
    TextBox txtBox2 = (TextBox) Controls.Find(controlNames[1])[0];
    MySqlConnection con = new MySqlConnection("connection string here");
    String query="INSERT INTO [TABLENAME]  
             ([COLUMNNAME1],[COLUMNNAME2]) VALUES(@COLUMNVALUE1 , @COLUMNVALUE2)";
    MySqlCommand command = new MySqlCommand(query,con);
    command.Parameters.AddWithValue("@COLUMNNAME1",txBox1.Text);
    command.Parameters.AddWithValue("@COLUMNNAME2",txBox2.Text);
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
