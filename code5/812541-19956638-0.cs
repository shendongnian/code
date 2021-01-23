    //Our test file to output
    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    
    //Standard PDF setup, nothing special here
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
    
                //Create our outer table with two columns
                var outerTable = new PdfPTable(2);
    
                //Create our inner table with just a single column
                var innerTable = new PdfPTable(1);
    
                //Add a middle-align cell to the new table
                var innerTableCell = new PdfPCell(new Phrase("Inner"));
                innerTableCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                innerTable.AddCell(innerTableCell);
    
                //Add the inner table to the outer table
                outerTable.AddCell(innerTable);
    
                //Create and add a vertically longer second cell to the outer table
                var outerTableCell = new PdfPCell(new Phrase("Hello\nWorld\nHello\nWorld"));
                outerTable.AddCell(outerTableCell);
    
                //Add the table to the document
                doc.Add(outerTable);
                
                doc.Close();
            }
        }
    }
