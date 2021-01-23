    private static void UpgradeApplicationSettingsIfNecessary()
    {
        // Application settings are stored in a subfolder named after the full #.#.#.# version number of the program. This means that when a new version of the program is installed, the old settings will not be available.
        // Fortunately, there's a method called Upgrade() that you can call to upgrade the settings from the old to the new folder.
        // We control when to do this by having a boolean setting called 'NeedSettingsUpgrade' which is defaulted to true. Therefore, the first time a new version of this program is run, it will have its default value of true.
        // This will cause the code below to call "Upgrade()" which copies the old settings to the new.
        // It then sets "NeedSettingsUpgrade" to false so the upgrade won't be done the next time.
    
        UserSetting Setting = new UserSetting();
        if (Setting.NeedSettingsUpgrade)
        {
            Properties.Settings.Default.Upgrade();
            System.Windows.Forms.MessageBox.Show("Settings Upgraded");
            Setting.NeedSettingsUpgrade = false;
        }
    }
