                    var tables = mainPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().ToList();
                    foreach (DocumentFormat.OpenXml.Wordprocessing.Table t in tables)
                    {
                        var rows = t.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>();
                        foreach (DocumentFormat.OpenXml.Wordprocessing.TableRow row in rows)
                        {
                            var cells = row.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCell>();
                            foreach (DocumentFormat.OpenXml.Wordprocessing.TableCell cell in cells)
                            {
                                if (cell.InnerText.Contains("#bNaam#"))
                                {
                                    //paragraph.InnerText will be empty
                                    Run newRun = new Run();
                                    newRun.AppendChild(new Text(cell.InnerText.Replace("#bNaam#", Parameters.Naam)));
                                    //remove any child runs
                                    cell.RemoveAllChildren<Run>();
                                    //add the newly created run
                                    cell.AppendChild(newRun);
                                }
                            }                          
                        }
                        
                    }
