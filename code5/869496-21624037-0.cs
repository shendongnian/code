    namespace Application.Web.Properties
    {
        public sealed partial class Settings
        {
            Settings()
            {
                this["AppConfig"] = new ApplicationConfiguration();
            }
        }
    }
