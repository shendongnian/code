    protected void BtnPDF_Click(object sender, EventArgs e)
        {
            GridView gv = new GridView();
            gv.DataSource = SqlDataSource1;
            gv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            var mem = new MemoryStream();
            Document document = new Document(PageSize.LETTER, 50, 50, 50, 50);
            PdfWriter.GetInstance(document,mem);
            document.Open();
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(sw.ToString()));
            document.Close();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
            Response.BinaryWrite(mem.ToArray());
            Response.End();
            Response.Flush();
            Response.Clear();
        }
