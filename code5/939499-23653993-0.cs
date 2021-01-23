    Excel.Worksheet NwSheet;
    Excel.Range ShtRange;
    //Getting Number of total sheets in workbook
    int SheetCount = xApp.Sheets.Count;
    for (int i = 1; i <= SheetCount; i++){
    NwSheet = (Excel.Worksheet)xApp.Sheets.get_Item(i);
    //Getting all used cells in sheet 
    ShtRange = NwSheet.UsedRange;
    // hiding phonetics from sheet
    ShtRange.Phonetic.Visible = false;
    }
