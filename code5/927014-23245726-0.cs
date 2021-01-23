            connectionString.Open();
            SqlCommand command =
                new SqlCommand(
                    "select LeaveCount from leaveallotment  where
                     id= '" + comboBox1.Text + "' and 
                     leavetype='" + comboBox2.Text + "'",
                    connectionString);
            SqlDataReader da = command.ExecuteReader();
            if (da.Read()) {
                textBox1.Text = da["LeaveCount"].ToString();
            }
            connectionString.Close();
