      Document myDocument = new Document(PageSize.A4, -60, -40, 10, 10);
      PdfPTable MainTable = new PdfPTable(1);
      PdfPCell pdfTableCell11 = new PdfPCell(new Paragraph("Hellod PDF!", RegularFont10));
      MainTable.AddCell(pdfTableCell11);
      string path =  "C:\\Customer\\";
      PdfWriter.GetInstance(myDocument, new FileStream(path + "\\Invoice_" + DateTime.Now.DayOfWeek + ".pdf", FileMode.Create));
      myDocument.Open();
      myDocument.Add(MainTable);
      myDocument.Close();
