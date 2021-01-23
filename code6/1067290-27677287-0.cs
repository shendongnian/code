    public class AppLayout
    {
        public static AppLayout Instance {
            get { ... }
        }
        public WebBrowserForm WebBrowser {get;private set;}
        public MainForm Main {get;private set;}
        public SettingsForm Settings {get;private set;}
    }
