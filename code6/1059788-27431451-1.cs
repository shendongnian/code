    private string Location="";
    private void LoginButton_Click(object sender, EventArgs e)
        {
    
     string commandText = "SELECT RIGHTS FROM [USER] WHERE Username=@p1 and [Password]=@p2";
         using (OleDbCommand command = new OleDbCommand(commandText, con))
         {
           command.Parameters.AddWithValue("@p1", textBox1.Text);
           command.Parameters.AddWithValue("@p2", textBox2.Text);
           string query = (string)command.ExecuteScalar();
           {
    
             if (query == "Manager")
             {
              string locationText = "SELECT LOCATION FROM [USER] WHERE Username=@p1 and [Password]=@p2";
              using (OleDbCommand location = new OleDbCommand(locationText, con))
              {
                location.Parameters.AddWithValue("@p1", textBox1.Text);
                location.Parameters.AddWithValue("@p2", textBox2.Text);
                string Location = (string)command.ExecuteScalar();
                {
    
                }
           }
         }
      }
     private void groupBox5_Enter(object sender, EventArgs e)
    {
       if(!Location.Equals("")){
        //Load Employee Name
        using (OleDbConnection con = new OleDbConnection(constring))
        {
            try
            {
                string query = "SELECT TellerNum FROM EMPLOYEE WHERE Location = @p1 ORDER     BY TellerNum ASC";
                location.Parameters.AddWithValue("@p1", Location);
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Name");
                comboBox14.DisplayMember = "TellerNum";
                comboBox14.DataSource = ds.Tables["Name"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          }
        }
    }
