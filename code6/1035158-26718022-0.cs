    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("msvcr71.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int _controlfp(int n, int mask);
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _controlfp(0x9001F, 0xFFFFF);
            // ... whatever else you want to do on application startup
            // e.g. add last-resort error handler via DispatcherUnhandledException
        }
    }
