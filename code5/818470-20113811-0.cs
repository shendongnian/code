    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = @"Data Source=|DataDirectory|\Database_POS.sdf";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText= "INSERT INTO Customer (Email) Values (@email);";
                command.Parameters.AddWithValue("@email",textBox_Email.Text);
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0)
                    MessageBox.Show("Data inserted successfully");
                else
                    MessageBox.Show("Nothing inserted into the database!");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show(ex.ToString()); // for debugging purpose
        }
    }
