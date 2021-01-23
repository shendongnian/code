    SqlConnection myConnection = new SqlConnection("server=SHASHAK\\SQLEXPRESS;" +
                       "Trusted_Connection=yes;" +
                       "database=Abhishek; " +
                       "connection timeout=30");
    private void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            using (myConnection)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Abhishek (player_id, player_name) VALUES (@playerid, @playername)", myConnection))
                {
                    cmd.Parameters.AddWithValue("@playerid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@playername", textBox2.Text);
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show("You failed!" + ex.Message);
        }
        catch (Exception ex)
        {
            //Show message / log
        }
    }
