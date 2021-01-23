    public System.Data.DataTable SetOne(string ExcelFilePath)
    {       
          System.Data.DataTable table = new System.Data.DataTable();
          Microsoft.Office.Interop.Excel.Application app = new                                Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(ExcelFilePath,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
               Type.Missing, Type.Missing);
                int NoOfSheetRows=0;
        foreach (Worksheet item in app.Worksheets)
        {
            string sheetname = item.Name;
            Worksheet sheet = (Worksheet)wb.Sheets[sheetname];
            Range excelRange = sheet.UsedRange;
            string fileRange = sheet.UsedRange.Address;
            string filecolums = fileRange.Substring(6, 1);
            List<string> str = new List<string>();
            int cntr = 0;
            foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
            {
                int rowNumber = row.Row;
                string[] A4D4 = this.GetRange("A" + rowNumber + ":" + filecolums + "" + rowNumber + "", sheet);
                if (rowNumber.Equals(1))
                {
                    foreach (var itm in A4D4)
                    {
                        if (table.Columns.Contains(itm)==false)
                        {
                            table.Columns.Add(itm);
                            str.Add(itm);
                            cntr++;
                        }
                        else
                        {
                            table.Columns.Add(itm + "..");
                            str.Add(itm);
                            cntr++;
                        }
                    }
                }
                else
                {
                    DataRow drow;
                    drow = table.NewRow();
                    drow.ItemArray = A4D4;
                    for(int i=0;i<A4D4.Length; i++)
                    {
                      drow= table.NewRow();
                      drow["name"] = A4D4[i];
                      table.Rows.Add(drow);
                    }
                   //table.Rows.InsertAt(drow, NoOfSheetRows);
                  //table.Rows.Add(drow); // This is Area where the Problem is created the the sheet 2,3,4 and so forth data is inserted to 1st Sheet Columns 
                }
            }
            NoOfSheetRows += cntr;
        }
        return table;
    }
    public string[] GetRange(string range, Worksheet excelWorksheet)
    {
        Microsoft.Office.Interop.Excel.Range workingRangeCells =
          excelWorksheet.get_Range(range, Type.Missing);
        System.Array array = (System.Array)workingRangeCells.Cells.Value2;
        string[] arrayS = array.OfType<object>().Select(o => o.ToString()).ToArray();
        return arrayS;
    }
