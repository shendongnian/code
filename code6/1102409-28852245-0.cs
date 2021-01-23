    var pdf = File.ReadAllBytes(@"D:\path\DynamicCrosstabSampleRpt.pdf"); // or an in-memory byte array
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = MediaTypeNames.Application.Pdf;
    Response.AddHeader("Content-Length", pdf.Length.ToString());
    Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
    // try inline mode as well
    // Response.AddHeader("content-disposition", "inline;filename=test.pdf");
    Response.Buffer = true;
    Response.Clear();
    Response.OutputStream.Write(pdf, 0, pdf.Length);
    Response.OutputStream.Flush();
    Response.OutputStream.Close();
    Response.End();
