    public static class OfficeHelper
    {
      /// <summary>
      ///   Forces a GC to release unused run time callable wrappers around COM objects
      /// </summary>
      /// <example>
      ///   dynamic rcw;
      ///   try
      ///   {
      ///      rcw = Globals.ThisWorkbook.ActiveSheet;
      ///      // do something
      ///      // ...
      ///    }
      ///    finally
      ///    {
      ///      rcw = null;
      ///      OfficeHelper.Cleanup();
      ///    }
      /// </example>
      public static void Cleanup()
      {
        System.Diagnostics.Debug.Print("OfficeHelper::Cleanup - GC forced");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        System.Diagnostics.Debug.Print("OfficeHelper::Cleanup - GC finished");
      }
