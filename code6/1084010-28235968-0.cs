        private static void CheckForUserSettingsUpgrade()
        {
            if (!Properties.Settings.Default.UserSettingsUpgradeRequired)
            {
                return;
            }
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.UserSettingsUpgradeRequired = false;
            Properties.Settings.Default.Save();
        }
