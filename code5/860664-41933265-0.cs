                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Table WHERE ([user] = '" + txtBox_UserName.Text + "'", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        lblMessage.Text ="Record Already Exists.";
                    }
                    else
                    {
                        lblMessage.Text ="Record Not Exists.";
                    }
                    reader.Close();
                    reader.Dispose();
                }
                sqlConnection.Close();
