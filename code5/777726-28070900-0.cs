    protected void Page_Load(object sender, EventArgs e)
    {
     .
     .       
     using (MemoryStream ms = new MemoryStream())
     {
      .
      .
      iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 54, 54);
      iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
      writer.PageEvent = new HeaderFooter();
      doc.Open();
      .
      .
      // make your document content..
      .
      .                   
      doc.Close();
      writer.Close();
      // output
      Response.ContentType = "application/pdf;";
      Response.AddHeader("Content-Disposition", "attachment; filename=clientfilename.pdf");
      byte[] pdf = ms.ToArray();
      Response.OutputStream.Write(pdf, 0, pdf.Length);
     }
     .
     .
     .
    }
    class HeaderFooter : PdfPageEventHelper
    {
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        // Make your table header using PdfPTable and name that tblHeader
        .
        . 
        tblHeader.WriteSelectedRows(0, -1, page.Left + document.LeftMargin, page.Top, writer.DirectContent);
        .
        .
        // Make your table footer using PdfPTable and name that tblFooter
        .
        . 
        tblFooter.WriteSelectedRows(0, -1, page.Left + document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin), writer.DirectContent);
    }
    }
