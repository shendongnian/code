              using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(filename, true))
                {
                    //For Diagonostice Only
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    WorkbookPart workbookPart = spreadSheet.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    string origninalSheetId = workbookPart.GetIdOfPart(worksheetPart);
                    WorksheetPart replacementPart = workbookPart.AddNewPart<WorksheetPart>();
                    string replacementPartId = workbookPart.GetIdOfPart(replacementPart);
                    OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                    OpenXmlWriter writer = OpenXmlWriter.Create(replacementPart);
                    int rec = 0;
                    #region Looping through data
                    while (reader.Read())
                    {
                        if (reader.ElementType == typeof(SheetData))
                        {
                            if (reader.IsEndElement)
                                continue;
                            writer.WriteStartElement(new SheetData());
                            for (int row = 0; row < listData.Count; row++)
                            {
                                if (!string.IsNullOrEmpty(listData[row].WorkOrder))
                                {
                                   
                                    Row newRow = new Row();
                                    writer.WriteStartElement(newRow);
                                    for (int col = 0; col < 5; col++)
                                    {
                                        Cell newCell = new Cell();
                                        CellValue cellValue = new CellValue();
                                        //assigning value 
                                        cellValue.Text = row.ToString();
                                        //appending the value to cell
                                        newCell.Append(cellValue);
                                        writer.WriteElement(newCell);
                                    }
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteEndElement();
                        }
                        else
                        {
                            if (reader.IsStartElement)
                            {
                                writer.WriteStartElement(reader);
                            }
                            else if (reader.IsEndElement)
                            {
                                writer.WriteEndElement();
                            }
                        }
                    }
                    #endregion
                    reader.Close();
                    writer.Close();
                    //replace the templateSheet with DataSheet.                  
                    Sheet sheet = workbookPart.Workbook.Descendants<Sheet>()
                           .Where(s => s.Id.Value.Equals(origninalSheetId)).First();
                    sheet.Id.Value = replacementPartId;
                    workbookPart.DeletePart(worksheetPart);
                }
