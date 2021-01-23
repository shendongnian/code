                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=blablabla"))
                {
                    connection.Open();
                    // prepare command
                    OleDbCommand command = new OleDbCommand("INSERT INTO Table1 (id, team, old) VALUES (?, ?, ?)", connection);
                    command.Parameters.Add("id", typeID).Value = newID;
                    command.Parameters.Add("team", typeTeam).Value = team;
                    command.Parameters.Add("old", typeOld).Value = oldID;
                    // add new record
                    command.ExecuteNonQuery();
