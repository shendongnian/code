    protected void btnExport_Click(object sender, EventArgs e)
        {
            // Reference your own GridView here
            if (GridView1.Rows.Count > 65535)
            {
                //DisplayError("Export to Excel is not allowed" +
                //    "due to excessive number of rows.");
                return;
            }
    
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=nameofexcelfile_" + DateTime.Now+".xls" );
            Response.Charset = "";
    
            // SetCacheability doesn't seem to make a difference (see update)
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
    
            Response.ContentType = "application/vnd.ms-excel";
    
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
    
            // Replace all gridview controls with literals
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            GridView1.PagerSettings.Visible = false;
            ClearControls(GridView1);
    
            System.Web.UI.HtmlControls.HtmlForm form
                = new System.Web.UI.HtmlControls.HtmlForm();
            Controls.Add(form);
            form.Controls.Add(GridView1GridView1);
            form.RenderControl(htmlWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
