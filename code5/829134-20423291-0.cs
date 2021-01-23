        string MyConS = "SERVER=localhost;" +
                     "DATABASE=prototype_db;" +
                     "UID=root;";`enter code here`
        
        
                        MySqlConnection conn = new MySqlConnection(MyConS);
                        MySqlCommand comm = conn.CreateCommand();
                        conn.Open();
                        comm.CommandText = "Select RouteTo,RouteFrom,nOofTrips from tbl_bill_addtrips where RouteFrom = '" + txtBillRouteFrom.Text + "' and RouteTo ='" + txtBillRouteTo.Text + "'";
                        MySqlDataReader Reader;
                        Reader = comm.ExecuteReader();
    int Trips = 1;                    
    while (Reader.Read())
                        {
                            
                            string to = Reader["RouteTo"].ToString();
                            string From = Reader["RouteFrom"].ToString();
                            Trips = Convert.ToInt32(Reader["nOofTrips"].ToString());
        
        
                            if (From.ToString() == txtBillRouteFrom.Text && to.ToString() == txtBillRouteTo.Text)
                            {
                                Trips++;
                                MySqlConnection conn2 = new MySqlConnection(MyConS);
                                conn2.Open();
                                MySqlCommand command = conn2.CreateCommand();
                                command.CommandText = "UPDATE tbl_bill_addtrips SET nOofTrips= '" + Trips.ToString() + "' where  RouteFrom='" + this.txtBillRouteFrom.Text + "'and RouteTo='" + this.txtBillRouteTo.Text + "'";
        
        
                            }
                        }
