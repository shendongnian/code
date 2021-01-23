    //Set our skip column to an invalid index to start with
    var colToSkip = -1;
    //Index loop variable
    var i = 0;
    foreach (DataGridViewColumn column in dataGridView2.Columns)
    {
        if( column is DataGridViewCheckBoxColumn)
        {
            colToSkip = i;
        }
        else
        {
            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,   fontTitle2));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
            pdfTable9.AddCell(cell);
        }
        i++;
    }
    
    foreach (DataGridViewRow row in dataGridView2.Rows)
    {
         i = 0;
         foreach (DataGridViewCell cell in row.Cells)
         {
             if( i != colToSkip )
             {
                 pdfTable9.AddCell(new Phrase(cell.Value.ToString(), fontTitle));
             }
             i++;
         }
    }
