    for (int i = 0; i <= GridView1.Rows.Count-1; i++)
            {
                    for (int j = 0; j <= GridView1.Columns.Count - 1; j++)
                    {
                        string cellText = Page.Server.HtmlDecode(GridView1.Rows[i].Cells[j].Text);
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(100, cellText, f2));
                        table.AddCell(cell);
                        
                    }
            }
            //--set the columns width----
            float[] columnWidths = new float[] { 5f, 11f, 10f, 20f,15f,20f,7f,40f };
            table.SetWidths(columnWidths);
