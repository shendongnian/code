    PdfPTable pdfTable= new PdfPTable(5);
    foreach(DataGridViewRow row in dataGridView1.Rows) {
        foreach (DataGridViewCell celli in row.Cells) {
            try {
                pdfTable.AddCell(celli.Value.ToString());
            }
            catch { }
        }
        doc.Add(pdfTable);
    }
