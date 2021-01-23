    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    int[,] fieldInfo = new int[4, 2] { { 1, 2 }, { 2, 4 }, { 3, 2 }, { 4, 2 } };
    object oFieldInfo = fieldInfo;
    xlApp = new Excel.Application();
    object missing = System.Reflection.Missing.Value;
    xlApp.Workbooks.OpenText(
        filepath,Excel.XlPlatform.xlWindows,
        1,
        Excel.XlTextParsingType.xlDelimited,
        Excel.XlTextQualifier.xlTextQualifierSingleQuote,
        false,
        false,
        false,
        true,
        false,
        false,
        missing,
        oFieldInfo,
        missing,
        missing, 
        missing, 
        missing, 
        missing 
            );
