      Excel.Application myExcelApp = null;
 
      try
      {
          myExcelApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application") as Excel.Application;
      }
      catch (System.Runtime.InteropServices.COMException e)
      {
          // Excel Not Running
          myExcelApp = new Microsoft.Office.Interop.Excel.Application();
      }
