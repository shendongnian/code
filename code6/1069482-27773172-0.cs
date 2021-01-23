    using System.Windows;
    using System.IO.IsolatedStorage;
    namespace MyApp
    {
        public static class OneTimeDialog
        {
            private static readonly IsolatedStorageSettings _settings = IsolatedStorageSettings.ApplicationSettings;
            public static void Show(string uniqueKey, string title, string message)
            {
                if (_settings.Contains(uniqueKey)) return;
                MessageBox.Show(message, title, MessageBoxButton.OK);
                _settings.Add(uniqueKey, true);
                _settings.Save();
            }
        }
    }
