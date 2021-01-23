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
            //we need to call .Value to get the value of the cell, but since a Phrase takes in
            //a String, we need to convert the .Value to a String using .ToString()
            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));  //this .Value property is that of a DataGridViewCell
            pdfTable.AddCell(pdfCell);
        } 
    }
