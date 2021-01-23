      if (txtSearch.Text != "")
            {
                try
                {
                    //  open connection
                    oCn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("sp_offer_search", oCn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Variable", SqlDbType.VarChar).Value = txtSearch.Text;
                    da.SelectCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = Session["customerId"];
                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Pending";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSourceID = String.Empty;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    oCn.Close();
                }
                            
            }
            else
            {
                GridView1.DataSourceID = "SqlDataSource1";
                SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand;
                GridView1.DataBind();
            }
