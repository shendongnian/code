     PdfPCell cell = null;
     cell = new PdfPCell(new Phrase("EmpCode", font));
     cell.HorizontalAlignment = Element.BOTTOM;
     table.AddCell(cell);
     cell = new PdfPCell(new Phrase("" + text+ "", font1));
     table.AddCell(cell);
