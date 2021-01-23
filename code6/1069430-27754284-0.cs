    private void exportDgvPDF(DataGridView dgvLoadAll, string filename)
    {
    
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
    
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
    
            Document doc = new Document(PageSize.A2.Rotate(), 1, 1, 1, 1);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();
    
            // I need to remove 21 columns since I have lots invisible "useless" columns .. will work on that later
            PdfPTable pdftable = new PdfPTable(dgvLoadAll.ColumnCount - 21);
    
            for (int j = 0; j < dgvLoadAll.Columns.Count - 21; j++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dgvLoadAll.Columns[j].HeaderText, text));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdftable.AddCell(cell);
            }
    
    
            pdftable.HeaderRows = 0;
    
        // i add foreach i hope this will help you 
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                for (int k = 0; k < dataGridView1.Columns.Count - 21; k++)
                {
                    if (dgvLoadAll[k, i].Value != null)
                    {
                     pdftable.AddCell(new Phrase(row.Cells[k].Value.ToString(), text));
                    }
                }
    
            }
    
    
            doc.Add(pdftable);
            doc.Close(); 
    
    
            }
