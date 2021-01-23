    protected void Export_to_Excel(object sender, EventArgs e)
        {
            //System.Diagnostics.Debugger.Break();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=PatientSearchReport.xls");
            Response.ContentType = "application/vnd.xlsx";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);  
            GridView1.RenderControl(htmlWrite);
            string html2 = Regex.Replace(stringWrite.ToString(), @"(<input type=""image""\/?[^>]+>)", @"", RegexOptions.IgnoreCase);
            html2 = Regex.Replace(html2, @"(<input class=""checkbox""\/?[^>]+>)", @"", RegexOptions.IgnoreCase);
            html2 = Regex.Replace(html2, @"(<a \/?[^>]+>)", @"", RegexOptions.IgnoreCase);
            Response.Write(html2.ToString());
            Response.End();
        }
