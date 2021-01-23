    public byte[] ExportToPdf(DataTable dt)
    {
        var mem = new MemoryStream();
        var doc = new Document(new Rectangle(100f, 300f));
        PdfWriter.GetInstance(doc, mem);
        doc.Open();
        doc.Add(new Paragraph("This is a custom size"));
        doc.Close();
        return mem.ToArray();
    }
