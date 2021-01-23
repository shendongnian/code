    public static void ExportDataSetToExcel(DataTable ds, string filename)
     {
	HttpResponse response = HttpContext.Current.Response;
	response.Clear();
	response.Buffer = true;
	response.Charset = "";
	
	response.ContentType = "application/vnd.ms-excel";
	
	using (StringWriter sw = new StringWriter()) {
		using (HtmlTextWriter htw = new HtmlTextWriter(sw)) {
			DataGrid dg = new DataGrid();
			dg.DataSource = ds;
			dg.DataBind();
			dg.RenderControl(htw);
			response.Charset = "UTF-8";
			response.ContentEncoding = System.Text.Encoding.UTF8;
			response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
			response.Output.Write(sw.ToString());
			response.End();
		}
	  }
    }
