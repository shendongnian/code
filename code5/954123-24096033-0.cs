    oleDbConnection.Open();
    OleDbCommand command = new OleDbCommand("SELECT * FROM CUSTOMER WHERE FLIGHTNO = '" + variables.depFlightNo + "'", oleDbConnection);
    OleDbDataReader reader = command.ExecuteReader();
    while (reader.Read())
        {
            string seat = reader[3].ToString();
            foreach (Button s in this.Controls)
            {
               if (s.Name == seat)
               {
                  s.BackColor = Color.Yellow;
               }
            }
        }
        reader.Close();
    
