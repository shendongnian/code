    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        Paragraph paragraph = new Paragraph("TITULO DE TODOS LOS REPORTES\n\n", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD));
        paragraph.Alignment = Element.ALIGN_CENTER;
        document.Add(paragraph);
      
        string temp = pintaTitulo();
        paragraph = new Paragraph(pintaTitulo(), globalDefs.font13B);
        document.Add(paragraph);
     }
