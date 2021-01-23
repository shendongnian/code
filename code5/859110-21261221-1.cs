    public class ConfigurationManagerWrapper : ICoolConfigurationProvider
    {
        public NameValueCollection GetScheduledTasksSection()
        {
            return (NameValueCollection)ConfigurationManager
                      .GetSection("ScheduledTasks");
        }
    }
