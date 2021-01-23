        Row row = worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>().FirstOrDefault();
       var totalnumberOfColumns = 0;
        if (row != null)
            {
                var spans = row.Spans != null ? row.Spans.InnerText : "";
                    if (spans != String.Empty)
                            {
                                //spans.Split(':')[1];
                                string[] columns = spans.Split(':');
                                startcolumnInuse = int.Parse(columns[0]);
                                endColumnInUse = int.Parse(columns[1]);
                                totalnumberOfColumns = int.Parse(columns[1]);
                            }
            }
