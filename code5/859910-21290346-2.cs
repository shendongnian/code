    namespace BaseProject
    {
        public class MyBaseApplication : System.Windows.Application
        {
             // A container the parent library can access
             public BaseProject.AppSettings Settings { get; set; }
             public MyBaseApplication()
             {
                 this.Settings = new BaseProject.AppSettings();
             }
        }
        public class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage
        {
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                var myApp = System.Windows.Application.Current as MyBaseApplication;
                // Will contain an instance of ChildProject.AppSettings
                var mySettings = myApp.Settings;
                string appName = appSettings.getAppName();
                int appVersion = appSettings.getAppVersion();
                App_Name.Text = appName;
                App_Version.Text = "" + appVersion;
            }
        }
    }
    namespace ChildProject
    {
        public class AppSettings : BaseProject.AppSettings
        {
            // Derived implementation
        }
        public class MyChildApplication : BaseProject.MyBaseApplication
        {
            public MyChildApplication() : base()
            {
                 // Overwrite the default assignment from the parent class with a new assignment
                 this.Settings = new ChildProject.AppSettings();
            }
        }
    }
