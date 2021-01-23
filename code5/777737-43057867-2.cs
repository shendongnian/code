     Document pdfDoc = new Document(PageSize.LEGAL.Rotate(), 10, 10, 25, 25);
     System.IO.MemoryStream mStream = new System.IO.MemoryStream();
     PdfWriter writer = PdfWriter.GetInstance(pdfDoc, mStream);
     MyCode.HeaderFooter headers = new MyCode.HeaderFooter();
     writer.PageEvent = headers;
