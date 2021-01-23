     protected void btnExport_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C://test1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
    
            try
            {
                
    
                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, fs);
                pdfDoc.Open();
                //Set Font Properties for PDF File
                Font fnt = FontFactory.GetFont("Times New Roman", 14);
                PdfPTable PdfTable = new PdfPTable(2);
                PdfPCell Cell = new PdfPCell();
                PdfTable.TotalWidth = 600f;
                float[] widths = new float[] { 4f, 8f };
                PdfTable.SetWidths(widths);
    
    
                PdfPCell cell = new PdfPCell(new Phrase("MOM TABLE HEADER"));
                cell.Rowspan = 2;   // this not working
                PdfTable.AddCell(cell);
                PdfTable.AddCell("Meeting By");
                PdfTable.AddCell("test1");
    
                pdfDoc.Add(PdfTable);
    
                pdfDoc.Close();
            }
            catch
            {
            }
            finally
            {
                fs.Close();
            }
        }
