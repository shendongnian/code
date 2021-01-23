    var gv = new GridView();
    gv.DataSource = reportdata;
    gv.DataBind();
    // style the header
    gv.HeaderRow.Height = Unit.Pixel(35);
    gv.HeaderRow.Cells[0].Text = "Some custom header text";
    gv.HeaderRow.Cells[0].Width = Unit.Pixel(400);
    for (int col = 0; col < gv.HeaderRow.Controls.Count; col++)
    {
        TableCell tc = gv.HeaderRow.Cells[col];
        tc.Style.Add("color", "#FFFFFF");
        tc.Style.Add("background-color", "#444");
        tc.Style.Add("border-color", bordercolor);
    }
    // And your code as follows
    Response.Clear();
    Response.Charset = "";
    Response.Buffer = true;
    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}",    "     ExportData.xls"));
    // Prompt for Open/Save/Cancel
    Response.Cache.SetCacheability(HttpCacheability.Private);
    Response.ContentType = "application/vnd.ms-excel";
    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    System.Web.UI.HtmlTextWriter htmlWrite =
         new HtmlTextWriter(stringWrite);
    gv.RenderControl(htmlWrite);
    Response.Write(stringWrite.ToString());
    Response.End();
