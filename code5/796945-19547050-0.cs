    private void SortExcel()
    {
        //Set up
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        Excel.Range oLastAACell;
        Excel.Range oFirstACell;
        //Start Excel and get Application object.
        oXL = new Excel.Application();
        oXL.Visible = true;
        //Get a new workbook.;
        oWB = (Excel._Workbook)(oXL.Workbooks.Open(@"C:\Book.Xlsx"));
        
        //Get Sheet Object
        oSheet = (Excel.Worksheet)oWB.Worksheets["Sheet1"];
       
        //Get complete last Row in Sheet (Not last used just last)     
        int intRows = oSheet.Rows.Count;
        //Get the last cell in Column F that has a value in it
        oLastAACell = (Excel.Range)oSheet.Cells[intRows, 27];
        oLastAACell = oLastAACell.End[Excel.XlDirection.xlUp];
        //Get First Cell of Data (A2)
        oFirstACell = (Excel.Range)oSheet.Cells[2, 1];
        //Get Entire Range of Data
        oRng = (Excel.Range)oSheet.Range[oFirstACell, oLastAACell];
        //Sort the range based on First Columns And 6th (in this case A and F)
        oRng.Sort(oRng.Columns[1, Type.Missing],Excel.XlSortOrder.xlAscending, // the first sort key Column 1 for Range
                  oRng.Columns[6, Type.Missing],Type.Missing, Excel.XlSortOrder.xlAscending,// second sort key Column 6 of the range
                  Type.Missing, Excel.XlSortOrder.xlAscending,  // third sort key nothing, but it wants one
                  Excel.XlYesNoGuess.xlGuess, Type.Missing, Type.Missing, 
                  Excel.XlSortOrientation.xlSortColumns, Excel.XlSortMethod.xlPinYin,   
                  Excel.XlSortDataOption.xlSortNormal,
                  Excel.XlSortDataOption.xlSortNormal, 
                  Excel.XlSortDataOption.xlSortNormal);
        }
