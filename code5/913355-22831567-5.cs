    public sealed class CustomConfigurationSection : ConfigurationSection
    {
        public CustomConfigurationSection() {
            Current = CurrentConfiguration.GetSection(CustomSectionName);
        }
    
        public static CustomConfigurationSection Current { get; private set; }
    }
