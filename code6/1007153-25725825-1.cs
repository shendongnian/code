      /// <summary>
      /// Method called when the process is exiting.
      /// </summary>
      private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
      {
         // do some logging?
      }
      /// <summary>
      /// Method called if an unhandled AppDomain exception occurs.
      /// </summary>
      private static void CurrentDomain_UnhandledException(object sender,
                                                           UnhandledExceptionEventArgs e)
      {
         // do some logging?
      }
