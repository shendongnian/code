        try
        {
            con.Open();
            if ((txtHiddenBus.Text == "NONE") && (txtHiddenRP.Text == "NONE"))
            {
                grdMarketingReport1.EmptyDataText = "No Records Found";
                grdMarketingReport1.DataSource = cmd.ExecuteReader();
                grdMarketingReport1.Columns[1].Visible = false;
                grdMarketingReport1.Columns[2].Visible = false;
                grdMarketingReport1.Columns[3].Visible = false;
                grdMarketingReport1.Columns[4].Visible = false;
                grdMarketingReport1.Columns[5].Visible = false;
                grdMarketingReport1.Columns[6].Visible = false;
                grdMarketingReport1.DataBind();
            }
            else if ((txtHiddenBus.Text != "NONE") && (txtHiddenRP.Text == "NONE"))
            {
                grdMarketingReport1.EmptyDataText = "No Records Found";
                grdMarketingReport1.DataSource = cmd.ExecuteReader();
                grdMarketingReport1.Columns[1].Visible = false;
                grdMarketingReport1.Columns[2].Visible = false;
             
                grdMarketingReport1.Columns[4].Visible = false;
                grdMarketingReport1.Columns[5].Visible = false;
                grdMarketingReport1.Columns[6].Visible = false;
                grdMarketingReport1.DataBind();
            }
            else
            {
                grdMarketingReport1.EmptyDataText = "No Records Found";
                grdMarketingReport1.DataSource = cmd.ExecuteReader();
                grdMarketingReport1.Columns[1].Visible = true;
                grdMarketingReport1.Columns[2].Visible = true;
                grdMarketingReport1.Columns[3].Visible = true;
                grdMarketingReport1.Columns[4].Visible = true;
                grdMarketingReport1.Columns[5].Visible = true;
                grdMarketingReport1.Columns[6].Visible = true;
                grdMarketingReport1.DataBind();
            }
          
      
        }
 
