        static WorksheetPart GetWorkSheetPart(WorkbookPart workbookPart, string sheetName)
        {
            //Get the relationship id of the sheetname
            string relId = workbookPart.Workbook.Descendants<Sheet>()
            .Where(s => s.Name.Value.Equals(sheetName))
            .First()
            .Id;
            return (WorksheetPart)workbookPart.GetPartById(relId);
        }
        static void FixupTableParts(WorksheetPart worksheetPart, int numTableDefParts)
        {
            //Every table needs a unique id and name
            foreach (TableDefinitionPart tableDefPart in worksheetPart.TableDefinitionParts)
            {
                tableId++;
                tableDefPart.Table.Id = (uint)tableId;
                tableDefPart.Table.DisplayName = "CopiedTable" + tableId;
                tableDefPart.Table.Name = "CopiedTable" + tableId;
                tableDefPart.Table.Save();
            }
        }
        private void CopySheet(SpreadsheetDocument mySpreadsheet, string sheetName, string clonedSheetName)
        {
            WorkbookPart workbookPart = mySpreadsheet.WorkbookPart;
            IEnumerable<Sheet> source = workbookPart.Workbook.Descendants<Sheet>();
            Sheet sheet = Enumerable.First<Sheet>(source, (Func<Sheet, bool>)(s => (string)s.Name == sheetName));
            string sheetWorkbookPartId = (string)sheet.Id;
            WorksheetPart sourceSheetPart = (WorksheetPart)workbookPart.GetPartById(sheetWorkbookPartId);
            SpreadsheetDocument tempSheet = SpreadsheetDocument.Create(new MemoryStream(), mySpreadsheet.DocumentType);
            WorkbookPart tempWorkbookPart = tempSheet.AddWorkbookPart();
            WorksheetPart tempWorksheetPart = tempWorkbookPart.AddPart<WorksheetPart>(sourceSheetPart);
            //Add cloned sheet and all associated parts to workbook
            WorksheetPart clonedSheet = workbookPart.AddPart<WorksheetPart>(tempWorksheetPart);
            int numTableDefParts = sourceSheetPart.GetPartsCountOfType<TableDefinitionPart>();
            tableId = numTableDefParts;
            if (numTableDefParts != 0)
                FixupTableParts(clonedSheet, numTableDefParts);
            CleanView(clonedSheet);
            //Add new sheet to main workbook part
            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
            Sheet copiedSheet = new Sheet();
            copiedSheet.Name = clonedSheetName;
            copiedSheet.Id = workbookPart.GetIdOfPart(clonedSheet);
            copiedSheet.SheetId = (uint)sheets.ChildElements.Count + 1;
            sheets.Append(copiedSheet);
            workbookPart.Workbook.Save();
        }
        static void CleanView(WorksheetPart worksheetPart)
        {
            SheetViews views = worksheetPart.Worksheet.GetFirstChild<SheetViews>();
            if (views != null)
            {
                views.Remove();
                worksheetPart.Worksheet.Save();
            }
        }
