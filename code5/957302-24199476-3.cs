    using (Document document = new Document(pagesize)) {
        // step 2
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        // step 3
        document.Open();
        // step 4
        PdfContentByte content = writer.DirectContent;
        PdfImportedPage page = writer.GetImportedPage(reader, 1);
        // adding the same page 16 times with a different offset
        float x, y;
        for (int i = 0; i < 16; i++) {
            x = -pagesize.Width * (i % 4);
            y = pagesize.Height * (i / 4 - 3);
            content.AddTemplate(page, x, y); // we don't scale anymore
            document.NewPage();
         }
    }
