    private void GetData()
    {
     try{
         using (MySqlSqlConnection connection = new MySqlSqlConnection(Connection.connectionString ))
         {
           connection.Open();
           //GetData
            connection.Close();
          }
     }
     catch
     {
         MessageBox.Show("An error occurred while trying to fetch Data");
     }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      //I would avoid this. 
      // Connection.cnn.Open();
    }
    
    //I am not sure why you are having this.
    private void timer1_Tick(object sender, EventArgs e)
    {
      //if (Connection.cnn.State == ConnectionState.Open)
      //{
      //  this.Text = "Connected";
      //}
      //else
      //{
      //  this.Text = "Disconnected";
      //  return; 
      //}
    }
