    Word._Application oWord;
                    Word._Document oDoc;
                    oWord = new Word.Application();
                    oWord.Visible = true;
                    object oTemplate = "C:/Users/Sean/Documents/Custom Office Templates/BMW Invoice.dotx";
                    oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing,
                        ref oMissing, ref oMissing);
                    Object start = Type.Missing;
                    Object end = Type.Missing;
                    object missing = System.Type.Missing;
                    Microsoft.Office.Interop.Word.Range rng = oDoc.Range(ref start, ref end);
                    Microsoft.Office.Interop.Word.Table tbl = oDoc.Tables.Add(rng, dataGridView1.Rows.Count, dataGridView1.Columns.Count, ref oMissing, ref oMissing);
                    Microsoft.Office.Interop.Word.Row newRow = oDoc.Tables[1].Rows.Add(ref missing);
                    newRow.Range.Font.Bold = 0;
                    newRow.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                    tbl.Cell(0, 0).WordWrap = false;
                    tbl.Cell(0, 0).FitText = true;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i == dataGridView1.Rows.Count - 1)
                            MessageBox.Show("Successfully Exported");
                        else
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
    
                                tbl.Cell(i + 1, j + 1).Range.Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
