    InteropExcel.Sheets sheets = null
    try
    {
      sheets = ....;
    }
    finally
    {
      if (sheets != null)
      {
        Marshal.FinalReleaseComObject(sheets);
        sheets = null;
      }
    }
