       protected void ExporttoExcel(object sender, EventArgs e)
       {
           //First, retrieve the DataTable from ViewState
           DataTable Dt = new DataTable();
           Dt = (DataTable)ViewState["DtData"];
    
           //Now you have the data, create a dummy GridView that will be used for exporting
           GridView grdView = new GridView();
           grdView.AllowPaging = false;
           grdView.DataSource = Dt;
           grdView.DataBind();
    
           //Do the Exporting stuff
           Response.Clear();
           Response.AddHeader("content-disposition", "attachment; filename=Report.xls");
           Response.ContentType = "application/vnd.xls";
           System.IO.StringWriter stringWrite = new System.IO.StringWriter();
           System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
           grdView.RenderControl(htmlWrite);
           Response.Write(stringWrite.ToString());
           Response.End();
       }
