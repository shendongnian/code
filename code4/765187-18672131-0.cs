    public class ChromeOptionsWithPrefs: ChromeOptions {
        public Dictionary<string,object> prefs { get; set; }
    }
    
    public static void Initialize() {
        var options = new ChromeOptionsWithPrefs();
        options.prefs = new Dictionary<string, object> {
            { "profile.default_content_settings", new Dictionary<string, object>() { "images", 2 } }
        };
        var driver = new ChromeDriver(options);
    }
