    var document = new Document();
    // Populate the MigraDoc document here
    ...
    // Render the document
    var renderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always)
    {
        Document = document
    };
    renderer.RenderDocument();
    // Create the custom outline
    var pdfSharpDoc = renderer.PdfDocument;
    var rootEntry = pdfSharpDoc.Outlines.Add(
        "Level 1 Header", pdfSharpDoc.Pages[0]);
    rootEntry.Outlines.Add("Level 2 Header", pdfSharpDoc.Pages[1]);
    // Etc.
    // Save the document
    pdfSharpDoc.Save(outputStream);
