    public void ExportToPdf(DataTable dt)
     {      
       Document document = new Document();
       PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("c://sample.pdf", FileMode.Create));
      document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
    PdfPTable table = new PdfPTable(dt.Columns.Count);
    PdfPRow row = null;
    float[] widths = new float[] { 4f, 4f, 4f, 4f };
    table.SetWidths(widths);
    table.WidthPercentage = 100;
    int iCol = 0;
    string colname = "";
    PdfPCell cell = new PdfPCell(new Phrase("Products"));
    cell.Colspan = dt.Columns.Count;
    foreach (DataColumn c in dt.Columns)
    {
        table.AddCell(new Phrase(c.ColumnName, font5));
    }
    foreach (DataRow r in dt.Rows)
    {
        if (dt.Rows.Count > 0)
        {
            table.AddCell(new Phrase(r[0].ToString(), font5));
            table.AddCell(new Phrase(r[1].ToString(), font5));
            table.AddCell(new Phrase(r[2].ToString(), font5));
            table.AddCell(new Phrase(r[3].ToString(), font5));
        }          
    }  document.Add(table);
        document.Close();
     }
