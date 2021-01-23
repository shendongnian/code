    //~~> Open File
    private void button1_Click(object sender, EventArgs e)
    {
    
        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        Microsoft.Office.Interop.Excel.Range xlRange;
        Microsoft.Office.Interop.Excel.Range xlFilteredRange;
    
        xlexcel = new Excel.Application();
    
        xlexcel.Visible = true;
    
        //~~>  Open a File
        xlWorkBook = xlexcel.Workbooks.Open("C:\\MyFile.xlsx",  0,  false, 5, "", "", true,
        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    
        //~~> Work with Sheet1
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
        //~~> Get last row in Col A
        int _lastRow = xlWorkSheet.Cells.Find(
                                      "*",
                                      xlWorkSheet.Cells[1,1],
                                      Excel.XlFindLookIn.xlFormulas,
                                      Excel.XlLookAt.xlPart,
                                      Excel.XlSearchOrder.xlByRows,
                                      Excel.XlSearchDirection.xlPrevious,
                                      misValue,
                                      misValue,
                                      misValue
                                      ).Row ;
    
        //~~> Set your range
        xlRange =  xlWorkSheet.Range["A1:A" + _lastRow];
    
        //~~> Remove any filters if there are
        xlWorkSheet.AutoFilterMode=false;
    
        //~~> Filter Col A for blank values
        xlRange.AutoFilter(1, "=", Excel.XlAutoFilterOperator.xlAnd, misValue, true);
    
        //~~> Identigy the range
        xlFilteredRange = xlRange.Offset[1,0].SpecialCells(Excel.XlCellType.xlCellTypeVisible,misValue);
    
        //~~> Delete the range in one go
        xlFilteredRange.EntireRow.Delete(Excel.XlDirection.xlUp);
    
        //~~> Remove filters
        xlWorkSheet.AutoFilterMode = false;
    
        //~~> Close and cleanup
        xlWorkBook.Close(true, misValue, misValue);
        xlexcel.Quit();
        releaseObject(xlRange);
        releaseObject(xlFilteredRange);    
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlexcel);
    }
    
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            MessageBox.Show("Unable to release the Object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
    }
