    protected void btnPrintToPDF_Click(object sender, EventArgs e)
        {
        //Default Settings for your PDF File
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", "PDFExport"));
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Initialize a StringSwriter
        StringWriter stringWrite = new StringWriter();
        DataTable dt = new DataTable();
        //Info line in PDF
        stringWrite.WriteLine("Clothing department");
        //Fetch DataTable
        dt = getDataTablebyProcedure("SelectFromClothingDepartment");
        //Append it to String Writer
        stringWrite = getStringWriterbyDataTable(dt, stringWrite);
        //Info line in PDF
        stringWrite.WriteLine("Food Department");
        //Fetch DataTable
        dt = getDataTablebyProcedure("SelectFromFoodDepartment");
        //Append it to Stwing Writer
        stringWrite = (getStringWriterbyDataTable(dt, stringWrite));
                
        //As many procedures as you want to go here
        //Finally Write the writer into a reader
        StringReader sr = new StringReader(stringWrite.ToString());
        //Generate the pdf
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
