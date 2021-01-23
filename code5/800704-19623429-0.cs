    static class Program
        {       
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TrayApplicationContext());
            }
        }
    
        public class TrayApplicationContext : ApplicationContext
        {
            private readonly NotifyIcon _trayIcon;
            public TrayApplicationContext()
            {
                _trayIcon = new NotifyIcon
                                {
                                    //it is very important to set an icon, otherwise  you won't see your tray Icon.
                                    Icon = Resources.AppIcon,                                
                                    Visible = true
                                };
            }        
        }
