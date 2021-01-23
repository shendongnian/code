    private static string RenderTableToString(HtmlTable table)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (var htw = new HtmlTextWriter(sw))
            {
                table.RenderControl(htw);
                var html = sw.ToString();
                return html;
            }
        }
    }
