    private void ExportthroughWeb(DataTable dt, string FileName)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string filename = FileName + ".xls";
    
                    using (System.IO.StringWriter tw = new System.IO.StringWriter())
                    {
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                        GridView dgGrid = new GridView();
                        dgGrid.DataSource = dt;
                        dgGrid.RowDataBound += new GridViewRowEventHandler(Grd_QADetails_RowDataBound);
                        dgGrid.DataBind();
    
                        //Get the HTML for the control.
                        dgGrid.RenderControl(hw);
                        //Write the HTML back to the browser.
    
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
    
                        Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">" + Environment.NewLine);
                        Response.Write(tw.ToString());
    
                        Response.Write("</body>");
                        Response.Write("</html>");
    
                        Response.End();
                    }
                }
