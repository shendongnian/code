    private void comboEditPlayer_SelectedIndexChanged(object sender, EventArgs e)
    {
          string connectionString =
              ZimbFootball.Properties.Settings.Default.Football2ConnectionString;
          using (SqlConnection connection = new SqlConnection (connectionString))
          using (SqlCommand command = new SqlCommand(
                        "SELECT * From Add_Players WHERE Player_ID =@id", connection))
          {
              connection.Open();
              command.Parameters.AddWithValue("@id", comboEditPlayer.Text);
              using(SqlDataReader myReader = command.ExecuteReader())
              {
                  while (myReader.Read())
                  {
                        comboEditPlayerPos.Items.Add(myReader[1]);
                        txtEditPlayerName.Text = myReader[2].ToString();
                        txtEditPlayerSecond.Text = myReader[3].ToString();
                        comboEditPlayerStatus.Items.Add(myReader[4]);
                  }
              }
           }
     }
