    public partial class CustomSettingsProvider : System.Configuration.SettingsProvider, System.Configuration.IApplicationSettingsProvider
    {
        // raise this event to cause the settings to be reloaded at runtime after initialization
        public static event EventHandler UpdateCustomSettings;
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();
            // the collection identifies properties to initialize
            foreach (SettingsProperty property in collection)
            {
                SettingsPropertyValue spv = new SettingsPropertyValue(property);
                
                // determine value...
                spv.PropertyValue = value;
                result.Add(spv);
            }
            return result;
        }
    }
