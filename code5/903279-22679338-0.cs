            string statement1 = @"INSERT INTO tblTicket_Engineer(TicketID,EngineerID) 
                            SELECT @ID,@EID1 UNION ALL
                            SELECT @ID,@EID2 UNION ALL
                            SELECT @ID,@EID3";
            using (SqlCommand command1 = new SqlCommand(statement1))
            using (SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ST"].ConnectionString.ToString()))
            {
                command1.Parameters.AddWithValue("@ID", PID);
                command1.Parameters.AddWithValue("@EID1", comboBox1.SelectedValue);
                command1.Parameters.AddWithValue("@EID2", comboBox2.SelectedValue);
                command1.Parameters.AddWithValue("@EID3", comboBox3.SelectedValue);
                connection1.Open();
                command1.Connection = connection1;
                command1.ExecuteNonQuery();
                connection1.Close();
