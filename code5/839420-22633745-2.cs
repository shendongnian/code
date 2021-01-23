    public class ProgramSettings
    {
        private readonly string _path;
        private readonly List<Setting> _settings;
        private readonly SettingProvider _settingProvider;
        private readonly ConsoleWriter _writer;
        public ProgramSettings(string programName, SettingProviderFactory settingProviderFactory, ConsoleWriter writer)
        {
            _writer = writer;
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = Path.Combine(appData, companyName, programName);
            _path = Path.Combine(folder, "settings.xml");
            _settings = new List<Setting>();
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            _settingProvider = settingProviderFactory.GetProvider(_path, _settings);
        }
        public Setting Add(string name, string description)
        {
            var setting = new Setting(name, description);
            _settings.Add(setting);
            return setting;
        }
        public string Load()
        {
            _settingProvider.Load();
            _writer.WriteLine("using config at " + _path);
            if (_settings.All(s => s.IsSet))
                return null;
            _settingProvider.Save();
            var description = string.Join("\n", _settings.Where(s => !s.IsSet).Select(s => s.Description));
            return description + "\n need setting in config";
        }
    }
