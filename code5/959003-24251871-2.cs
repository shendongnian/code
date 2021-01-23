    public class iOSUserPreferences : IUserPreferences 
    {
        public void SetString(string key, string value)
        {
            NSUserDefaults.StandardUserDefaults.SetString(key, value);
        }
        public string GetString(string key)
        {
            (...)
        }
    }
