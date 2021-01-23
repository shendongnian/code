    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledExceptionEvent;
            }
            private static void HandleUnhandledExceptionEvent(Object sender, System.UnhandledExceptionEventArgs e)
            {
                //write details to file or output to console, popup message, etc.
            }
        }
    }
