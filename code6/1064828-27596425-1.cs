        if (count == 1)
        {
            connection.Open(); // <-------------FIRST TIME
            Form main = new AdminMain();
            main.Show();
            this.Hide();
            try
            {
                connection.Open();// <-------------SECOND TIME
                command.Connection = connection;
                command.CommandText = "INSERT into LogHisto ([Username],[LogDate],[LogTime]) values ('" + txtUser.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }
