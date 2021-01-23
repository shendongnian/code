    public class SessionSettings : ISessionSettings
    {
        private readonly HttpSessionStateBase _session;
        public SessionSettings(HttpSessionStateBase session)
        {
            _session = session;
        }
        public T Get<T>(string key)
        {
            return (T)_session[key];
        }
        public void Set<T>(string key, T value)
        {
            _session[key] = value;
        }
    }
    public interface ISessionSettings
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
    }
    public class Sut
    {
        private ISessionSettings _sessionSettings;
        public Sut(ISessionSettings sessionSettings)
        {
            _sessionSettings = sessionSettings;
        }
        public string GetCartId(HttpContextBase context)
        {
            if (_sessionSettings.Get<string>(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    _sessionSettings.Set<string>(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    _sessionSettings.Set<string>(CartSessionKey, tempCartId.ToString());
                }
            }
            return _sessionSettings.Get<string>(CartSessionKey);
        }
        private string CartSessionKey = "key";
    }
