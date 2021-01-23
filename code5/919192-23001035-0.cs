    public class Plugin
    {
        public List<PluginSetting> Settings { get; set; }
        public string Name { get; set; }
    }
    public class PluginSetting
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
