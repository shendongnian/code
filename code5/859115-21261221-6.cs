    public class SUT
    {
        private IConfigurationProvider _configProvider;
        public SUT(IConfigurationProvider configProvider)
        {
            _configProvider = configProvider;
        }
        public void Exercise()
        {
            var dict = _configProvider.GetScheduledTasksSettings();
            // ...
        }
    }
