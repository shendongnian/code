      public static class EnvInfo
      {
          public static string GetEdition()
          {
            EnvDTE.DTE dte =(EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            return dte.Edition;
          }
      }
  
