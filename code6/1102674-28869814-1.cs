    String src = dataDir + "Page numbers.docx";
    String dst = dataDir + "Page numbers_out.docx";
                
    // Create a new document or load from disk
    Aspose.Words.Document doc = new Aspose.Words.Document(src);
    // Create a document builder
    Aspose.Words.DocumentBuilder builder = new DocumentBuilder(doc);
    // Go to the primary footer
    builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
    // Add fields for current page number
    builder.InsertField("PAGE", "");
    // Add any custom text
    builder.Write(" / ");
    // Add field for total page numbers in document
    builder.InsertField("NUMPAGES", "");
    // Import new document
    Aspose.Words.Document newDoc = new Aspose.Words.Document(dataDir + "new.docx");
    // Link the header/footer of first section to previous document
    newDoc.FirstSection.HeadersFooters.LinkToPrevious(true);
    doc.AppendDocument(newDoc, ImportFormatMode.UseDestinationStyles);
    // Save the document
    doc.Save(dst);
