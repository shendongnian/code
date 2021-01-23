    public void DownloadExcel_Click(object sender, EventArgs e)
        {
            var downloadLink = (Control)sender;
            GridViewRow row = (GridViewRow)downloadLink.NamingContainer;
            Label lblProduct = (Label)row.FindControl("lblprodname");
            string prodName = lblProduct.Text;
            Label lblCompany = (Label)row.FindControl("lblcompname");
            string compName = lblCompany.Text;
            Label lblRecords  = (Label)row.FindControl("lblrecords");
            int noOfRecords = Convert.ToInt32(lblRecords.Text);
            DataTable dt = (DataTable)Session["UserHistoryProduct"];
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_getProductHistory", con);
            
                cmd.Parameters.Add("@ProdName", SqlDbType.VarChar, 1000).Value = prodName;
                cmd.Parameters.Add("@CompName", SqlDbType.VarChar, 1000).Value = compName;
                cmd.Parameters.Add("@noOfRecords", SqlDbType.Int).Value = noOfRecords;
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            //dt.Load(dr);
            //dr.Close();
            con.Close();
            Session["UserHistoryProduct"] = dt;
            //DataTable Searchtable = (DataTable)Session["UserHistoryProduct"];
            ExportToExcel(dt);
            
        }
