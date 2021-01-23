    PdfPTable pdfTable= new PdfPTable(5);
    foreach(DataGridViewRow row in dataGridView1.Rows) {
        foreach (DataGridViewCell celli in row.Cells) {
            pdfTable.AddCell(celli.Value.ToString());
        }
    }
    doc.Add(pdfTable);
