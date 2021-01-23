                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                Document doc = new Document(PageSize.A2.Rotate(), 1, 1, 1, 1);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                doc.Open();
                // sort selected columns and rows indexes in order to be exported how they are viewed in datagridview
                columnsList.Sort();
                rowsselected.Sort();
                PdfPTable pdftable = new PdfPTable(columnsList.Count);
                foreach (int columnindex in columnsList)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dgvLoadAll.Columns[columnindex].HeaderText, text));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    pdftable.AddCell(cell);
                }
                pdftable.HeaderRows = 0;
                foreach (int rowindex in rowsselected)
                {
                    foreach (int columnindex in columnsList)
                    {
                        if (dgvLoadAll[columnindex, rowindex].Value != null)
                        {
                            pdftable.AddCell(new Phrase(dgvLoadAll.Rows[rowindex].Cells[columnindex].Value.ToString(), text));
                        }
                    }
                }
                //float[] widths = new float[] { 15f, 50f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f, 40f };
                // pdftable.SetWidths(widths);
                doc.Add(pdftable);
                doc.Close();
                rowsselected.Clear();
