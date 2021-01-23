    public static void ExportPDF(DataTable dt1, DataTable dt2)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", "PDFExport"));
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //For First DataTable
        System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
        DataGrid myDataGrid1 = new DataGrid();
        myDataGrid1.DataSource = dt1;
        myDataGrid1.DataBind();
        myDataGrid1.RenderControl(htmlWrite1);
        //For Second DataTable 
        System.IO.StringWriter stringWrite2 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite2 = new HtmlTextWriter(stringWrite2);
        DataGrid myDataGrid2 = new DataGrid();
        myDataGrid2.DataSource = dt2;
        myDataGrid2.DataBind();
        myDataGrid2.RenderControl(htmlWrite2);
        //You can add more DataTable
        StringReader sr = new StringReader(stringWrite1.ToString() + stringWrite2.ToString());
        Document pdfDoc = new Document(new Rectangle(288f, 144f), 10f, 10f, 10f, 0f);
        pdfDoc.SetPageSize(PageSize.A4.Rotate());
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        HttpContext.Current.Response.Write(pdfDoc);
        HttpContext.Current.Response.End();
    }
