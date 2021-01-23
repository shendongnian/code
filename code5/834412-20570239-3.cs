    class Config
    {
        // Select the correct object using a string, or enum, or int, or ...
        public static ISettings SetCurrentSettings(string selectedSettings)
        {
            switch (selectedSettings)
            {
                default:
                case "Settings":
                    CurrentSettings = Properties.Settings.Default;
                    break;
                case "Settings1":
                    CurrentSettings = Properties.Settings1.Default;
                    break;
                case "Settings2":
                    CurrentSettings = Properties.Settings2.Default;
                    break;
            }
            return CurrentSettings;
        }
        public static ISettings CurrentSettings { get; private set; }
    }
