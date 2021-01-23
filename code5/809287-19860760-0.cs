     protected void Export_to_Excel(object sender, EventArgs e)
     {
    GridView tmpGrid = new GridView();
    // here bind this grid with same datasource which you have used for GridView1 
    
    //System.Diagnostics.Debugger.Break();
    Response.Clear();
    Response.AddHeader("content-disposition", "attachment;filename=vault-extract-nsf.xls");
    Response.ContentType = "application/vnd.xlsx";
    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    tmpGrid.RenderControl(htmlWrite);
    Response.Write(stringWrite.ToString());
    Response.End();
    }
