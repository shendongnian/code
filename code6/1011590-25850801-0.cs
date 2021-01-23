    public interface INotificationProvider
    {
        /// <summary>
        /// Friendly Name for logging/tracing usage
        /// </summary>
        string FriendlyName { get; set; }
        /// <summary>
        /// Generates and returns an INotificationOutput from data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        INotificationOutput GenerateNotificationOutput(INotificationInput data);
    }
