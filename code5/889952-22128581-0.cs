    private void LoadGrid()
            {
                Thread BackgroundThread = new Thread
                    (
                    new ThreadStart(() =>
                    {
                        ConnectionStringSettings consetting = ConfigurationManager.ConnectionStrings["AutoDB"];
    
                             String ConnectionString = consetting.ConnectionString;
    
                             SqlConnection con = new SqlConnection(ConnectionString);
    
                                 SqlCommand command = new SqlCommand();
                                 DataSet ds = new DataSet();
                                 SqlDataAdapter da = new SqlDataAdapter();
    
                                 int i = 0;
    
                                 con.Open();
                                 command.Connection = con;
                                 command.CommandType = CommandType.StoredProcedure;
                                 command.CommandText = "LoadAllCustomers";
    
    
                                 da.SelectCommand = command;
                                 da.Fill(ds, "dbo.TblCustomers");
    
                        GridCustomerList.BeginInvoke(
                         new Action(() =>
                         {
    
                             GridCustomerList.DataSource = ds.Tables["dbo.TblCustomers"];
                             
                         }
                         ));
                    }
    
                    ));
                BackgroundThread.Start();
    
                
            }
