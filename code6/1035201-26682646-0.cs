       public static class VsIdeTestHostContext
       {
          [CLSCompliant(false)]
          public static DTE Dte { get; }
          public static IServiceProvider ServiceProvider { get; set; }
       }
