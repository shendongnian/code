    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
        //This remains empty
    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        htmlWrite.Write("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
        htmlWrite.Write("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
        htmlWrite.Write("xmlns=\"http://www.w3.org/TR/REC-html40\"> ");
        htmlWrite.Write("<head> ");
        htmlWrite.Write("<!--[if gte mso 9]><xml> ");
        htmlWrite.Write("<x:ExcelWorkbook> ");
        htmlWrite.Write("<x:ExcelWorksheets> ");
        htmlWrite.Write("<x:ExcelWorksheet> ");
        htmlWrite.Write("<x:Name>Sheet1</x:Name> ");
        htmlWrite.Write("<x:WorksheetOptions> ");
        htmlWrite.Write("<x:Selected/> ");
        htmlWrite.Write("<x:ProtectContents>False</x:ProtectContents> ");
        htmlWrite.Write("<x:ProtectObjects>False</x:ProtectObjects> ");
        htmlWrite.Write("<x:ProtectScenarios>False</x:ProtectScenarios> ");
        htmlWrite.Write("</x:WorksheetOptions> ");
        htmlWrite.Write("</x:ExcelWorksheet> ");
        htmlWrite.Write("</x:ExcelWorksheets> ");
        htmlWrite.Write("</x:ExcelWorkbook> ");
        htmlWrite.Write("</xml><![endif]--> ");
        htmlWrite.Write("</head>");
        htmlWrite.WriteLine("");
        gridView.HeaderStyle.Reset();
        gridView.FooterStyle.Reset();
        gridView.AlternatingRowStyle.Reset();
        gridView.RowStyle.Reset();
        gridView.BackColor = Color.Transparent;
        gridView.GridLines = GridLines.None;
        gridView.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
