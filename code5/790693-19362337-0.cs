    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var application = new Application();
    
                var workbookCopyingFrom = application.Workbooks.Open("a.xlsx");
                var workbookCopyingTo = application.Workbooks.Open("b.xlsx");
    
                var worksheetContainingRangeIWantToCopyAcross = workbookCopyingFrom.Sheets[1] as Worksheet;
    
                if (worksheetContainingRangeIWantToCopyAcross != null)
                {
                    var worksheetIWantToCopyToInWorkbookTwo = workbookCopyingTo.Sheets[2] as Worksheet;
    
                    if (worksheetIWantToCopyToInWorkbookTwo != null)
                    {
                        var usedRangeInWorkbookCopyingTo = worksheetIWantToCopyToInWorkbookTwo.UsedRange;
    
                        worksheetContainingRangeIWantToCopyAcross.UsedRange.Insert(XlInsertShiftDirection.xlShiftDown,
                                                                                   usedRangeInWorkbookCopyingTo);
    
                        worksheetIWantToCopyToInWorkbookTwo.Rows.Clear();
    
                        worksheetIWantToCopyToInWorkbookTwo.Rows.Insert(
                            CopyOrigin: worksheetContainingRangeIWantToCopyAcross);
                    }
                }
    
                workbookCopyingTo.Save();
                workbookCopyingTo.Close();
    
                application.Quit();
    
                Marshal.ReleaseComObject(application);
            }
        }
    }
