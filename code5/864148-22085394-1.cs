    public class PluginHost
    {
        public const string PluginRelativePath = @"plugins";
        private static readonly object SyncRoot = new object();
        private readonly string _pluginDirectory;
        private const string PluginDomainName = "Plugins";
        private readonly Dictionary<string, DateTime> _pluginModifiedDateDictionary = new Dictionary<string, DateTime>();
        private PluginDomain _domain;
        public PluginHost()
        {
            _pluginDirectory = AppDomain.CurrentDomain.BaseDirectory + PluginRelativePath;
            CreatePluginDomain(PluginDomainName, _pluginDirectory);
            Task.Factory.StartNew(() => CheckForPluginUpdatesForever(PluginDomainName, _pluginDirectory));
        }
        private void CreatePluginDomain(string pluginDomainName, string pluginDirectory)
        {
            _domain = new PluginDomain(pluginDomainName, pluginDirectory);
            var files = GetPluginFiles(pluginDirectory);
            _pluginModifiedDateDictionary.Clear();
            foreach (var file in files)
            {
                _pluginModifiedDateDictionary[file] = File.GetLastWriteTime(file);
            }
        }
        public void CallEach<T>(Action<T> call) where T : IPlugin
        {
            lock (SyncRoot)
            {
                var plugins = _domain.Resolve<IEnumerable<T>>();
                if (plugins == null)
                    return;
                foreach (var plugin in plugins)
                {
                    call(plugin);
                }
            }
        }
        private void CheckForPluginUpdatesForever(string pluginDomainName, string pluginDirectory)
        {
            TryCheckForPluginUpdates(pluginDomainName, pluginDirectory);
            Task.Delay(5000).ContinueWith(task => CheckForPluginUpdatesForever(pluginDomainName, pluginDirectory));
        }
        private void TryCheckForPluginUpdates(string pluginDomainName, string pluginDirectory)
        {
            try
            {
                CheckForPluginUpdates(pluginDomainName, pluginDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to check for plugin updates.", ex);
            }
        }
        private void CheckForPluginUpdates(string pluginDomainName, string pluginDirectory)
        {
            var arePluginsUpdated = ArePluginsUpdated(pluginDirectory);
            if (arePluginsUpdated)
                RecreatePluginDomain(pluginDomainName, pluginDirectory);
        }
        private bool ArePluginsUpdated(string pluginDirectory)
        {
            var files = GetPluginFiles(pluginDirectory);
            if (IsFileCountChanged(files))
                return true;
            return AreModifiedDatesChanged(files);
        }
        private static List<string> GetPluginFiles(string pluginDirectory)
        {
            if (!Directory.Exists(pluginDirectory))
                return new List<string>();
            return Directory.GetFiles(pluginDirectory, "*.dll").ToList();
        }
        private bool IsFileCountChanged(List<string> files)
        {
            return files.Count > _pluginModifiedDateDictionary.Count || files.Count < _pluginModifiedDateDictionary.Count;
        }
        private bool AreModifiedDatesChanged(List<string> files)
        {
            return files.Any(IsModifiedDateChanged);
        }
        private bool IsModifiedDateChanged(string file)
        {
            DateTime oldModifiedDate;
            if (!_pluginModifiedDateDictionary.TryGetValue(file, out oldModifiedDate))
                return true;
            var newModifiedDate = File.GetLastWriteTime(file);
            return oldModifiedDate != newModifiedDate;
        }
        private void RecreatePluginDomain(string pluginDomainName, string pluginDirectory)
        {
            lock (SyncRoot)
            {
                DestroyPluginDomain();
                CreatePluginDomain(pluginDomainName, pluginDirectory);
            }
        }
        private void DestroyPluginDomain()
        {
            if (_domain != null)
                _domain.Dispose();
        }
    }
