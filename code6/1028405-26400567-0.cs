    public class SomeSettings : ConfigurationSection
    {
        private SomeSettings() { }
    
        [ConfigurationProperty("FillColor", DefaultValue="Cyan")]
        public System.Drawing.Color FillColor
        {
            get { return (System.Drawing.Color)this["FillColor"]; }
            set { this["FillColor"] = value; }
        }
    
        [ConfigurationProperty("TextSize", DefaultValue="8.5")]
        public float TextSize
        {
            get { return (float)this["TextSize"]; }
            set { this["TextSize"] = value; }
        }
    
        [ConfigurationProperty("FillOpacity", DefaultValue="40")]
        public byte FillOpacity
        {
            get { return (byte)this["FillOpacity"]; }
            set { this["FillOpacity"] = value; }
        }
    }
