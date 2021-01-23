    // save your datatable in session while binding gridview
        // Session["Dt_GridView"]=Your_datatable; 
        protected void FilterResult(object sender, EventArgs e)
        {
            try
            {
               // DataTable dt = (DataTable)gvwResavePositions.DataSource; this reutrn null
                // hence
                //gvwResavePositions.DataSource as DataTable this will return null
    
    
    
                DataTable dt = (DataTable)Session["Dt_GridView"];
                
             dt.DefaultView.RowFilter = string.Format("strPaperId = '{0}'",
                    txtPaperId.Text);
             gvwResavePositions.DataSource = dt;
              gvwResavePositions.DataBind();
                }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
        }
