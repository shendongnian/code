    try
            {
                using (SqlConnection connection = new SqlConnection(yourConnectionString))
                {
                    connection.Open();
                    command = new SqlCommand("SELECT * FROM movies", connection);
                    SqlDataAdapter adapvare = new SqlDataAdapter(command, connection);
                    System.Data.DataSet dsFald = new System.Data.DataSet();
                    adapvare.Fill(dsFald, "movies");
                    tableDataGrid.DataContext = dsFald.Tables["movies"].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
