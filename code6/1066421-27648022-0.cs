    string confirmValue = Request.Form["confirm_value"];
    if (confirmValue == "Yes")
    {
        string sPathToWritePdfTo = @"C:\new_pdf_name.pdf";
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        sbHtml.Append("Contractor1.aspx");  // you have to pass HTML string here
        using (System.IO.Stream stream = new System.IO.FileStream(sPathToWritePdfTo, System.IO.FileMode.OpenOrCreate))
        {
            Pdfizer.HtmlToPdfConverter htmlToPdf = new Pdfizer.HtmlToPdfConverter();
            htmlToPdf.Open(stream);
            htmlToPdf.Run(sbHtml.ToString());//error
            htmlToPdf.AddChapter("Mobily");
            htmlToPdf.Close();
        }
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "mobily.pdf"));
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.WriteFile(sPathToWritePdfTo);
        HttpContext.Current.Response.End();
    }
