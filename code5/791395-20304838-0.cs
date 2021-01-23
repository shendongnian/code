    public bool UpdateValue(WorkbookPart wbPart, string sheetName, string addressName, string value,
                                UInt32Value styleIndex, CellValues dataType)
        {
            // Assume failure.
            bool updated = false;
            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where(
                (s) => s.Name == sheetName).FirstOrDefault();
            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);
                if (dataType == CellValues.SharedString)
                {
                    // Either retrieve the index of an existing string,
                    // or insert the string into the shared string table
                    // and get the index of the new item.
                    int stringIndex = InsertSharedStringItem(wbPart, value);
                    cell.CellValue = new CellValue(stringIndex.ToString());
                }
                else
                {
                    cell.CellValue = new CellValue(value);
                }
                cell.DataType = new EnumValue<CellValues>(dataType);
                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;
                // Save the worksheet.
                ws.Save();
                updated = true;
            }
            return updated;
        }
