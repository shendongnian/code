            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(@"E:\test.xlsx");
            Excel.Sheets ExcelSheets = ExcelWorkBook.Worksheets;
            Excel.Worksheet Sheet = (Excel.Worksheet)ExcelSheets.get_Item("Sheet1");
            Excel.Range allCellsInColumn = Sheet.get_Range("B:B");
            Excel.Range usedCells = allCellsInColumn.Find("DE", LookAt: Excel.XlLookAt.xlWhole, SearchOrder: Excel.XlSearchOrder.xlByRows, SearchDirection: Excel.XlSearchDirection.xlNext);
            string firstFound = usedCells.get_Address();
            Excel.Range next = allCellsInColumn.FindNext(usedCells);
            string nextFound = next.get_Address();
            int count = 1;
            while (nextFound != firstFound)
            {
                next = allCellsInColumn.FindNext(next);
                nextFound = next.get_Address(); 
                count++;
            }
            Console.WriteLine("Search Found in {0} Rows",count);
            ExcelWorkBook.Save();
            ExcelWorkBook.Close();
            ExcelApp.Quit();
 
