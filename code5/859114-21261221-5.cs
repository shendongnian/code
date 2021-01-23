    public class ConfigurationManagerWrapper : IConfigurationProvider
    {
        public NameValueCollection GetScheduledTasksSettings()
        {
            return (NameValueCollection)ConfigurationManager
                      .GetSection("ScheduledTasks");
        }
    }
