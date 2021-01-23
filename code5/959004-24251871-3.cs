    public class AndroidUserPreferences : IUserPreferences
    {
        public void SetString(string key, string value)
        {
            var prefs = Application.Context.GetSharedPreferences("MySharedPrefs", FileCreationMode.Private);
            var prefsEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }
        public string GetString(string key)
        {
            (...)
        }
    }
