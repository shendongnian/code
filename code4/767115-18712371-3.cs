    if (xlApp != null)
    {
      ExcelDataSourceHelper.GetWindowThreadProcessId(new IntPtr(xlApp.Resource.Hwnd), ref excelProcessId);
    }
    
    if (excelProcessId > 0)
    {
        XlHelper.KillProcess(excelProcessId);
    }
    
    public static void KillProcess(int excelProcessId)
    {
        if (excelProcessId > 0)
        {
            System.Diagnostics.Process ExcelProc = null;
            try
            {
                ExcelProc = System.Diagnostics.Process.GetProcessById(excelProcessId);
                if (ExcelProc != null)
                {
                    ExcelProc.Kill();
                }
            }
            catch
            { }
        }
    }
