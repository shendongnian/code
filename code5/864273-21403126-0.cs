    private void UpdateData()
            {
                try
                {
                    MainWindow.cmdSel = new SqlCommand("SELECT Name FROM Cities order by ID asc", MainWindow.conn);
                    DataSet dtst = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter(); 
                    try
                    {
    
                        adpt.SelectCommand = MainWindow.cmdSel;
                        adpt.Fill(dtst, "Cities");
                        lstCity.DataContext = dtst;
    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
    
    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
    
                }
            }
