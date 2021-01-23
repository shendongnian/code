    // step 1
    using (Document document = new Document()) {
        // step 2
        using (PdfSmartCopy copy = new PdfSmartCopy(document, ms)) {
            // step 3
            document.Open();
            // step 4
            AddDataSheets(copy);
        }
     }
