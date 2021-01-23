    public class Service : System.Web.Services.WebService
    {
        public Service()
            : this(InMemoryTokensProvider.GetInstance())
        {
        }
        public Service(TokensProvider statePersister)
        {
            _tokens = statePersister;
        }
        private TokensProvider _tokens;
        [WebMethod]
        public string ServiceCall() 
        {
            if (_tokens.Contains("TestToken"))
            {
                return "Token was present!";
            }
            else
            {
                _tokens.Add("TestToken");
                return "Token was added!";
            }
        }
    }
    public interface TokensProvider
    {
        void Add(string token);
        bool Contains(string token);
    }
    public class InMemoryTokensProvider : TokensProvider
    {
        private static InMemoryTokensProvider _instance;
        public static TokensProvider GetInstance()
        {
            if (_instance == null) _instance = new InMemoryTokensProvider();
            return _instance;
        }
        private HashSet<string> _tokens = new HashSet<string>();
        public void Add(string token)
        {
            lock (_tokens)
            {
                _tokens.Add(token);
            }
        }
        public bool Contains(string token)
        {
            lock (_tokens)
            {
                return _tokens.Contains(token);
            }
        }
    }
