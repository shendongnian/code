         public void createPdf()
                 {
            	// step 1
                     using (MemoryStream ms = new MemoryStream())
                     {
                         Document document = new Document(iTextSharp.text.PageSize.A4, 10, 22, 34, 34);
                         // step 2
                         PdfWriter writer = PdfWriter.GetInstance(document, ms);
                         // step 3
                         document.Open();
                         MemoryStream stream = new MemoryStream();
                         // step 4 how many tables you want to create
                         for (int i = 0; i < 5; i++)
                         {
                             document.Add(new Paragraph("Table:"));
                             document.Add(createFirstTable());
                             
                         }                     
     // step 5
                         document.Close();
                         writer.Close();
                         Response.ContentType = "pdf/application";
                         Response.AddHeader("content-disposition",
                         "attachment;filename=First PDF document.pdf");
                         Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                     }
                 }
        
                public static PdfPTable createFirstTable(DataTable dt)
                {
        
        
                    // a table with three columns
                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    // the cell object
                    PdfPCell cell;
                    // we add a cell with colspan 3
                    //cell = new PdfPCell(new Phrase("Cell with colspan 3"));
                    
                   
                   table.AddCell(cell);
                    //// now we add a cell with rowspan 2
                    cell = new PdfPCell(new Phrase("Cell with rowspan 2"));
                    
                        table.AddCell("ADXHGS");
                    table.AddCell("WFEWSA");
                    table.AddCell("EWSFCEDSW");
                    table.AddCell("EWSEWSFDFCEDSW");
        
        
                   
                    //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
                    
                    return table;
                }
