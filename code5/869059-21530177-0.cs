        [STAThread]
        public static void Main()
        {
            // let IDE to handle exceptions
            if (System.Diagnostics.Debugger.IsAttached)
                Run();
            else
                try
                {
                    Application.ThreadException += Application_ThreadException;
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    Run();
                }
                catch (Exception e)
                {
                    // catch exceptions outside of Application.Run
                    UnhandledException(e);
                }
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // catch non-ui exceptions
            UnhandledException(e.ExceptionObject as Exception);
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // catch ui exceptions
            UnhandledException(e.Exception);
        }
        private static void UnhandledException(Exception e)
        {
            try
            {
                // here we restart app
            }
            catch
            {
                // if we are here - things are really really bad
            }
        }
