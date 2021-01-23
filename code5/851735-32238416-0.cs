    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'base.VerifyRenderingInServerForm(control);
        'This remains empty
    End Sub
    Protected Sub btnExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnExcel.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        htmlWrite.Write("<html xmlns:o=""urn:schemas-microsoft-com:office:office"" ")
        htmlWrite.Write("xmlns:x=""urn:schemas-microsoft-com:office:excel"" ")
        htmlWrite.Write("xmlns=""http://www.w3.org/TR/REC-html40""> ")
        htmlWrite.Write("<head> ")
        htmlWrite.Write("<!--[if gte mso 9]><xml> ")
        htmlWrite.Write("<x:ExcelWorkbook> ")
        htmlWrite.Write("<x:ExcelWorksheets> ")
        htmlWrite.Write("<x:ExcelWorksheet> ")
        htmlWrite.Write("<x:Name>Sheet1</x:Name> ")
        htmlWrite.Write("<x:WorksheetOptions> ")
        htmlWrite.Write("<x:Selected/> ")
        htmlWrite.Write("<x:ProtectContents>False</x:ProtectContents> ")
        htmlWrite.Write("<x:ProtectObjects>False</x:ProtectObjects> ")
        htmlWrite.Write("<x:ProtectScenarios>False</x:ProtectScenarios> ")
        htmlWrite.Write("</x:WorksheetOptions> ")
        htmlWrite.Write("</x:ExcelWorksheet> ")
        htmlWrite.Write("</x:ExcelWorksheets> ")
        htmlWrite.Write("</x:ExcelWorkbook> ")
        htmlWrite.Write("</xml><![endif]--> ")
        htmlWrite.Write("</head>")
        htmlWrite.WriteLine("")
        gridView.HeaderStyle.Reset()
        gridView.FooterStyle.Reset()
        gridView.AlternatingRowStyle.Reset()
        gridView.RowStyle.Reset()
        gridView.BackColor = Color.Transparent
        gridView.GridLines = GridLines.None
        gridView.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.[End]()
    End Sub
