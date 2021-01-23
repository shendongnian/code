     private void YourTextBox_KeyDown(object sender, KeyEventArgs e)
            {
     String connection= "Data Source=YourServer;Initial Catalog=YourDatabase;user=User;password=YourPassword;Integrated Security=True;";
            if (e.KeyCode == Keys.Enter)
            {
    string insertCmdText = "INSERT INTO table(column1)values(@valueForColumn1)";
    SqlCommand sqlCom = new SqlCommand(insertCmdText,connection);
    sqlCom.Paramaters.AddWithValue("@valueForColumn1",YourTextBox.Text);
    connection.Open();
    sqlCom.ExecuteNonQuery();
    connection.Close();
            }
        }
