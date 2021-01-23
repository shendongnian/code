    Microsoft.Office.Interop.Excel.Range range = cSheet.UsedRange;
    string address = range.get_Address();
    string[] cells = address.Split(new char[] {':'});
    string beginCell = cells[0].Replace("$", "");
    string endCell = cells[1].Replace("$", "");
