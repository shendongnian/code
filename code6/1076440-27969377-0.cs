    //Adding Header row
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
        pdfTable.AddCell(cell);
    }   
    //Lets add code that actually gets the cell contents down below it:
    //add the cell contents
    foreach(DataGridViewRow row in dataGridView1.Rows) { 
        foreach(DataGridViewCell cell in row.Cells) { 
            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value));  //this .Value property is that of a DataGridViewCell
            pdfTable.AddCell(pdfCell);
        } 
    }
