    private void btnSubmit_Click(object sender, EventArgs e)
    { 
       static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\chathuranga\documents\visual studio 2012\Projects\SansipProtoType\SansipProtoType\SansipDataBase.mdf;Integrated Security=True";);
            string name = txtName.Text;
            conn.Open();
            SqlCommand myCommand = new SqlCommand("INSERT INTO UserName VALUES (@Username)", conn);
            myCommand.ExecuteNonQuery();
    
     
      lblMessage.Text = "Record added successfully";
      txtName.Text = "";
      conn.close();
    }
