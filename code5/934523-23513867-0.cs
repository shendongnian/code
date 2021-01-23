    private static void ConvertTableToHTML()
        {
            try
            {
                foreach (Table tb in Common.WordApplication.ActiveDocument.Tables)
                {
                    for (int r = 1; r <= tb.Rows.Count; r++)
                    {
                        for (int c = 1; c <= tb.Columns.Count; c++)
                        {
                            try
                            {
                                Cell cell = tb.Cell(r, c);
                                foreach (Paragraph paragraph in cell.Range.Paragraphs)
                                {
                                    Tagging(paragraph.Range, "P");
                                }
                                Tagging(cell.Range, "TD");                                
                            }
                            catch (Exception e)
                            {
                                if (e.Message.Contains("The requested member of the collection does not exist."))
                                {
                                    //Most likely a part of a merged cell, so skip over.
                                }
                                else throw;
                            }
                        }
                        try
                        {
                            Row row = tb.Rows[r];
                            Tagging(row.Range, "TR");                            
                        }
                        catch (Exception ex)
                        {
                            bool initialTrTagInserted = false;
                            int columnsIndex = 1;
                            int columnsCount = tb.Columns.Count;
                            while (!initialTrTagInserted && columnsIndex <= columnsCount)
                            {
                                try
                                {
                                    Cell cell = tb.Cell(r, columnsIndex);
                                    cell.Range.InsertBefore("<TR>");
                                    initialTrTagInserted = true;
                                }
                                catch (Exception e)
                                {
                                }
                                columnsIndex++;
                            }
                            columnsIndex = tb.Columns.Count;
                            bool endTrTagInserted = false;
                            while (!endTrTagInserted && columnsIndex >= 1)
                            {
                                try
                                {
                                    Cell cell = tb.Cell(r, columnsIndex);
                                    cell.Range.InsertAfter("</TR>");
                                    endTrTagInserted = true;
                                }
                                catch (Exception e)
                                {
                                }
                                columnsIndex--;
                            }
                        }
                    }
                    Common.Tagging2(tb.Range, "Table");                    
                    object separator = "";
                    object nestedTable = true;
                    tb.ConvertToText(separator, nestedTable);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
 
    public static void Tagging(Range range, string TagName)
        {
            try
            {
                range.InsertBefore("<" + TagName + ">");
                range.InsertAfter("</" + TagName + ">");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
