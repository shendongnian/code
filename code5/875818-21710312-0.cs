    // Used the ExtractPages as a starting point.
    public void MergeDocuments(string sourcePdfPath1, string sourcePdfPath2, 
        string outputPdfPath, int insertPage) {
        PdfReader reader1 = null;
        PdfReader reader2 = null;
        Document sourceDocument1 = null;
        Document sourceDocument2 = null;
        PdfCopy pdfCopyProvider = null;
        PdfImportedPage importedPage = null;
        try {
            reader1 = new PdfReader(sourcePdfPath1);
            reader2 = new PdfReader(sourcePdfPath1);
 
            // Note, I'm assuming pages are 0 based.  If that's not the case, change to 1.
            sourceDocument1 = new Document(reader1.GetPageSizeWithRotation(0));
            sourceDocument2 = new Document(reader2.GetPageSizeWithRotation(0));
 
            pdfCopyProvider = new PdfCopy(sourceDocument1, 
                new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
 
            sourceDocument1.Open();
            sourceDocument2.Open();
 
            int length1 = reader1.getNumberOfPages();
            int length2 = reader2.getNumberOfPages();
            int page1 = 0; // Also here I'm assuming pages are 0-based.
            // Having these three loops is the key.  First is pages before the merge.          
            for (;page1 < insertPage && page1 < length1; page1++) {
                importedPage = pdfCopyProvider.GetImportedPage(reader1, page1);
                pdfCopyProvider.AddPage(importedPage);
            }
            // These are the pages from the second document.
            for (int page2 = 0; page2 < length2; page2++) {
                importedPage = pdfCopyProvider.GetImportedPage(reader2, page2);
                pdfCopyProvider.AddPage(importedPage);
            }
            // Finally, add the remaining pages from the first document.
            for (;page1 < length1; page1++) {
                importedPage = pdfCopyProvider.GetImportedPage(reader1, page1);
                pdfCopyProvider.AddPage(importedPage);
            }
            sourceDocument1.Close();
            sourceDocument2.Close();
            reader1.Close();
            reader2.Close();
        } catch (Exception ex) {
            throw ex;
        }
    }
