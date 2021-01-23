    public void Start()
        {
            Row RowTemplate = null;
            UInt32 indexFirst = 0;
            bool FLAG = true; 
            File.Copy(Path + shblonName, Path + newName, true);
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(Path + newName, true))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == "Лист1");
                if (!sheets.Any())
                {
                    throw new Exception("не найден лист");
                }
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart) document.WorkbookPart.GetPartById(relationshipId);
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                foreach (var row in worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>())
                {
                    foreach (var cell in row.Descendants<Cell>())
                    {
                        if (cell != null)
                        {
                            var vvv = GetVal(cell, document.WorkbookPart);
                            if (vvv.IndexOf("DataField:", System.StringComparison.Ordinal) != -1)
                            {
                                var ind = Convert.ToUInt32(Regex.Replace(cell.CellReference.Value, @"[^\d]+", ""));
                                if (FLAG)
                                {
                                    indexFirst = ind;
                                    FLAG = false;
                                    RowTemplate = row;
                                }
                                MyFields.Add(new MyData(ind
                                    ,new string(cell.CellReference.Value.ToCharArray().Where(p => !char.IsDigit(p)).ToArray())
                                    , vvv.Replace("DataField:", ""), cell));
                            }
                        }
                    }
                }
                foreach (DataRow item in data.Rows)
                {
                    Row row1 = new Row();
                    row1.RowIndex = indexFirst;
                    foreach (var fil in MyFields)
                    {
                        Cell cell1 = new Cell(fil.CellTemplate.CloneNode(true)); 
                        cell1.CellReference = fil.Column + indexFirst;
                        CellValue cellValue1 = new CellValue();
                        cellValue1.Text = item[fil.Property].ToString();
                        cell1.Append(cellValue1);
                        row1.Append(cell1);
                    }
                    sheetData.InsertBefore(row1, RowTemplate);
                    indexFirst++;
                }
            }
        }
        private string GetVal(Cell cell, WorkbookPart wbPart)
        {
            string value = cell.InnerText;
            if (cell.DataType != null)
            {
                switch (cell.DataType.Value)
                {
                    case CellValues.SharedString:
                        var stringTable =
                            wbPart.GetPartsOfType<SharedStringTablePart>()
                            .FirstOrDefault();
                        if (stringTable != null)
                        {
                            value =
                                stringTable.SharedStringTable
                                .ElementAt(int.Parse(value)).InnerText;
                        }
                        break;
                }
            }
            return value;
        }
