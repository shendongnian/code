    public static byte[] UnificarImagenesPDF(IEnumerable<DocumentoDTO> documentos)// "documents" is a list of objects that are located in the database, the images and pdf are stored in a binary attribute of "documents" 
    {
     using (MemoryStream workStream = new MemoryStream())
     {
      iTextSharp.text.Document doc = new iTextSharp.text.Document();//to create a itextSharp Document
      PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
      doc.Open();
      foreach (DocumentoDTO d in documentos)// "documentos" has an attribute where the document extension type is saved (eg pdf, jpg, png, etc) 
      {
       try
       {
        if (d.sExtension == ".pdf")
      {
       MemoryStream ms = new MemoryStream(d.bBinarios.ToArray());
       PdfReader pdfReader = new PdfReader(ms); // 
        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
       {
       PdfImportedPage page = writer.GetImportedPage(pdfReader, i);
       doc.Add(resizeImagen(iTextSharp.text.Image.GetInstance(page)));//Each sheet of the PDF document is added to the document created in itextsharp, and the resizeImage function is used so that the images are centered in the ITEXTSHARP document
       doc.NewPage();// add a new page on ITEXTSHARP document
       }
      }
    if (d.sExtension != ".pdf")
     {
      doc.Add(resizeImagen(Image.GetInstance((byte[])d.bBinarios)));
      doc.NewPage();
     }
    }
     catch
     {  }
    }
       doc.Close();
       writer.Close();
       return workStream.ToArray();
    }
    }
    private static iTextSharp.text.Image resizeImagen(iTextSharp.text.Image image)
    {
       if (image.Height > image.Width)
       {
       //Maximum height is 800 pixels.
       float percentage = 0.0f;
       percentage = 700 / image.Height;
       image.ScalePercent(percentage * 100);
       }
       else
       {
      //Maximum width is 600 pixels.
      float percentage = 0.0f;
      percentage = 540 / image.Width;
      image.ScalePercent(percentage * 100);
       }
      return image;
    }
