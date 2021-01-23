    public partial class App : Application
    {
        public static event EventHandler SettingsSaved;
        private async void Application_Launching(object sender, LaunchingEventArgs e)
        {
            //this await will cause the thread to jump to MainPage to subscribe to SettingsSaved event.
            await Task.Delay(500);
            
            if (SettingsSaved != null)
            {
                SettingsSaved(this, null);
            }
     }
