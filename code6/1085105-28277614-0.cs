    protected void btnExport_Click(object sender, EventArgs e)
       {
            iTextSharp.text.Document doc;
           
            Response.AddHeader("content-disposition", "attachment;filename=KeywordPositionReport.doc");
            Response.Charset = "";
           
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/doc";
    
           
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            this.fillgridview();
            this.PersonPerformance();
             Report.RenderControl(htmlWrite);
            string strBuilder = stringWrite.ToString();
            Response.Write(stringWrite.ToString());
            Response.End();
           
      
        }
