    SqlDataAdapter da = new SqlDataAdapter("Select * from Table", con);
                    DataTable dt = new DataTable("Call Reciept");
                    da.Fill(dt);
                    DataGrid dg = new DataGrid();
                    dg.ItemsSource = dt.DefaultView;
