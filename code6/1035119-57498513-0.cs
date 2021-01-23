    public static byte[] UnificarImagenesPDF(IEnumerable<DocumentoDTO> documentos)
    {
     using (MemoryStream workStream = new MemoryStream())
     {
      iTextSharp.text.Document doc = new iTextSharp.text.Document();
      PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
      doc.Open();
      foreach (DocumentoDTO d in documentos)
      {
       try
       {
        if (d.sExtension == ".pdf")
      {
       MemoryStream ms = new MemoryStream(d.bBinarios.ToArray());
       PdfReader pdfReader = new PdfReader(ms);
        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
       {
       PdfImportedPage page = writer.GetImportedPage(pdfReader, i);
       doc.Add(resizeImagen(iTextSharp.text.Image.GetInstance(page)));
       doc.NewPage();
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
