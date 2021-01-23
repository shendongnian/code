    try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Osman\Documents\osmanDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    SqlDataAdapter adapvare = new SqlDataAdapter("SELECT * FROM osmanTable", con);
                    System.Data.DataSet dsFald = new System.Data.DataSet();
                    adapvare.Fill(dsFald, "osmanTable");
                    osmanGrid.DataContext = dsFald.Tables["osmanTable"].DefaultView;
                    tableDataGrid.DataContext = dsFald.Tables["osmanTable"].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
