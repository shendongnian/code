                    cnn.Close();
                    command.CommandText = sql;
                    cnn.Open();
                    int lines = command.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
