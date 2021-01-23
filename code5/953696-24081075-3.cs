    // write on start of each page
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        ...
        tabHead.WriteSelectedRows(0, -1, document.Left, document.Top, writer.DirectContent);
    }
