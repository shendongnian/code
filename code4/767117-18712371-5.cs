    foreach (object possibleSheet in xlApp.Resource.Sheets)
    {
        Microsoft.Office.Interop.Excel.Worksheet aSheet = possibleSheet as Microsoft.Office.Interop.Excel.Worksheet;
        if (aSheet == null)
            continue;
