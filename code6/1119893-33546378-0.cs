    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    Workbook wb;
    Worksheet ws;
    Range range;
    int[,] a = new int[,] { { 1, 1 }, { 2, 2 }, { 3, 2 }, { 4, 2 }, { 5, 2 }, { 6, 2 }, { 7, 2 }, { 8, 2 }, { 9, 2 }, { 10, 2 }, { 11, 2 }, { 12, 2 }, { 13, 2 }, { 14, 2 }, { 15, 2 }, { 16, 2 }, { 17, 2 }, { 18, 2 }, { 19, 2 }, { 20, 2 }, { 21, 2 }, { 22, 2 } };
    excelApp.Workbooks.OpenText(ofdGetExcel.FileName,
                                                65001,
                                                1,
                                                XlTextParsingType.xlDelimited,
                                                XlTextQualifier.xlTextQualifierDoubleQuote,
                                                false,
                                                false,
                                                false,
                                                true,
                                                false,
                                                false,
                                                false,
                                                a,
                                                Type.Missing,//",",
                                                Type.Missing,//".",
                                                Type.Missing,//false,
                                                Type.Missing);//false);
    wb = excelApp.ActiveWorkbook;
    ws = wb.Worksheets.get_Item(1);
    range = ws.get_Range("A2");
    Microsoft.Office.Interop.Excel.QueryTable QT = ws.QueryTables.Add("TEXT;" + ofdGetExcel.FileName, range);
    QT.Name = ofdGetExcel.FileName;
    QT.FieldNames = true;
    QT.RowNumbers = true;
    QT.FillAdjacentFormulas = false;
    QT.PreserveFormatting = true;
    QT.RefreshOnFileOpen = false;
    QT.RefreshStyle = Microsoft.Office.Interop.Excel.XlCellInsertionMode.xlInsertDeleteCells;
    QT.SavePassword = false;
    QT.SaveData = true;
    QT.AdjustColumnWidth = true;
    QT.RefreshPeriod = 0;
    QT.TextFilePromptOnRefresh = false;
    QT.TextFilePlatform = 65001;
    QT.TextFileStartRow = 1;
    QT.TextFileParseType = Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited;
    QT.TextFileTextQualifier = Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierDoubleQuote;
    QT.TextFileConsecutiveDelimiter = false;
    QT.TextFileTabDelimiter = false;
    QT.TextFileSemicolonDelimiter = false;
    QT.TextFileCommaDelimiter = true;
    QT.TextFileSpaceDelimiter = false;
    QT.TextFileDecimalSeparator = ",";
    QT.TextFileThousandsSeparator = ".";
    ws.QueryTables[1].Destination.EntireColumn.AutoFit();
    ws.QueryTables[1].Refresh(false);
    ws.QueryTables[1].Delete();
