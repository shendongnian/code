    var doc = new Document();
    var pdf = "D:/Temp/pdfs/" + DateTime.Now.ToString("yyyymmdd") + ".pdf"; // mm ??
    var fi = new FileInfo(pdf);
    var di = fi.Directory;
    if (!di.Exists)
    {
        di.Create();
    }
    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdf, FileMode.Create));
    doc.Open();
    PdfContentByte cb = writer.DirectContent;
    ColumnText ct = new ColumnText(cb);
    Phrase myText = new Phrase("TEST paragraph\nNewline");
    ct.SetSimpleColumn(myText, 34, 750, 580, 317, 15, Element.ALIGN_LEFT);
    ct.Go();
    doc.Close();
