    void ExportDataSetToExcel(GridView grdData, string filename)
    {
        grdData.BorderStyle = BorderStyle.Solid;
        grdData.BorderWidth = 1;
        grdData.BackColor = Color.WhiteSmoke;
        grdData.GridLines = GridLines.Both;
        grdData.Font.Name = "Verdana";
        grdData.Font.Size = FontUnit.XXSmall;
        grdData.HeaderStyle.BackColor = Color.DimGray;
        grdData.HeaderStyle.ForeColor = Color.White;
        grdData.RowStyle.HorizontalAlign = HorizontalAlign.Left;
        grdData.RowStyle.VerticalAlign = VerticalAlign.Top;
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.Charset = "";
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename+ "\"");
        using (var sw = new StringWriter())
        {
            using (var htw = new HtmlTextWriter(sw))
            {
                grdData.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }
        }
    }
