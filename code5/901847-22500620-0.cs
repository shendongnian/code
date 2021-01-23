    public interface IUrl
    {
        Url Url { get; } 
    }
    internal class ControllerBasedUrl : IUrl
    {
        public ControllerBasedUrl(string controllerName)
        {
            this.Url = null; // implement
        }
        public Url Url { get; private set; }
    }
    internal class AppConfigBasedUrl : IUrl
    {
        public AppConfigBasedUrl()
        {
            this.Url = null; // implement
        }
        public Url Url { get; private set; }
    }
