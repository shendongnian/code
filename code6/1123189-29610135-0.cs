    using (var ms = new MemoryStream())
    {
        using (var doc = new Document(PageSize.A4, 50, 50, 25, 25))                     {
            //Create a writer that's bound to our PDF abstraction and our stream
            using (var writer = PdfWriter.GetInstance(doc, ms))
            {
    
                //Open the document for writing
                doc.Open();
    
                var courier9RedFont = FontFactory.GetFont("Courier", 9, BaseColor.RED);
                var importantNotice = new Paragraph("Sit on a potato pan Otis - if you don't agree that that's the best palindrome ever, I will sic Paladin on you, or at least say, 'All down but nine - set 'em up on the other alley, pard'", courier9RedFont);
                importantNotice.Leading = 0;
                importantNotice.MultipliedLeading = 0.9F; // reduce the width between lines in the paragraph with these two settings
    
                // Add a single-cell, borderless, left-aligned, half-page, table
                PdfPTable table = new PdfPTable(1);
                PdfPCell cellImportantNote = new PdfPCell(importantNotice);
                cellImportantNote.BorderWidth = PdfPCell.NO_BORDER;
                table.WidthPercentage = 50;
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellImportantNote);
                doc.Add(table);
    
                doc.Close();
            }
            var bytes = ms.ToArray();
            String PDFTestOutputFileName = String.Format("iTextSharp_{0}.pdf", DateTime.Now.ToShortTimeString());
            PDFTestOutputFileName = PDFTestOutputFileName.Replace(":", "_");
            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), PDFTestOutputFileName);
            File.WriteAllBytes(testFile, bytes);
            MessageBox.Show(String.Format("{0} written", PDFTestOutputFileName));
        }
    }
