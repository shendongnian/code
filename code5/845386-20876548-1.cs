    private void CreateGrid()
    {
            DataSet dsServiceId;
            dsServiceId = FetchServiceId();
            int countServices;
            countServices = dsServiceId.Tables[0].Rows.Count;
            //----
            Table t = new Table();
            TableRow row = new TableRow(); 
            //---
            for (int i = 0; i < countServices; i++)
            {
                int serviceid = Convert.ToInt32(dsServiceId.Tables[0].Rows[i]["pServiceID"].ToString());
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlCommand cmd = new SqlCommand("Ezy_opWiseSaleAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@Serviceid", serviceid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView gv = new GridView();
                gv.ID = "_gridview" + i;
                gv.DataSource = ds;
                gv.DataBind();
                //-----
                TableCell cell = new TableCell();
                cell.Controls.Add(gv);
                row.Controls.Add(cell);
                //------
            }
            //------
            t.Controls.Add(row);
            PlaceHolder1.Controls.Add(t);
            //------
    }
