    // ....
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetUnhandledExceptionHandler();
            // ...
    #region -- SetUnhandledExceptionsHandler() Method --
        /// <summary>
        /// Causes all unhandled exceptions to be handled by the application.
        /// This will not prevent the application from being forced to close, but
        /// does give a chance to log the error.
        /// </summary>
        public static void SetUnhandledExceptionHandler()
        {
            // Add an exception handler for all UI thread exceptions
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            // Set the unhandled exception mode to force all Windows Forms errors to
            // Go through this handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Add the event handler for handling non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
    #endregion
