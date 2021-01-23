    // Open Word
    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
    // Open some html file
    Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(@"E:\Test2.html");
    // Loop through all the pictures
    for (int i = 1; i <= doc.InlineShapes.Count; i++)
    {
        // Mark it as embedded if it's not
        if (doc.InlineShapes[i].LinkFormat != null && doc.InlineShapes[i].LinkFormat.SavePictureWithDocument == false)
        {
            doc.InlineShapes[i].LinkFormat.SavePictureWithDocument = true;
        }
    }
    // Save as docx
    doc.SaveAs2(@"e:\Test2.docx", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault);
    // Close word
    wordApp.Quit(Type.Missing, Type.Missing, Type.Missing);
