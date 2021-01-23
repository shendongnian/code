    public class BasicViewModel
    {
        public Page Page { get; set; }
        public List<Settings> Settings { get; set; }
    }
    public class Page
    {
        public string PageName { get; set; }
    }
    public class Settings
    {
        public string SettingName { get; set; }
    }
