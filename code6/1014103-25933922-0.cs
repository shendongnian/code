    Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 20, 10);
    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("submitted.pdf", FileMode.Create));
    doc.Open();
    // do your generating code here
    doc.Close();
    System.Diagnostics.Process.Start("filepath\\submitted.pdf");
    System.IO.File.Delete("filepath\\submitted.pdf");
