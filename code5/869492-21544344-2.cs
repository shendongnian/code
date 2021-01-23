    [SettingsProvider(typeof(CustomSettingsProvider))]
    internal sealed partial class Settings : ApplicationSettingsBase 
    {
        public Settings()
        {
            CustomSettingsProvider.UpdateCustomSettings += delegate(object sender, EventArgs e)
            {
                this.Reload();
            };
        }
    }
