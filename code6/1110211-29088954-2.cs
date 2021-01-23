    public class InMemoryInstances
    {
        private static volatile InMemoryInstances instance;
        private static object syncRoot = new Object();
        private List<Guid> activeTokens;
        private InMemoryInstances() 
        {
            activeTokens = new List<Guid>();
        }
        public static InMemoryInstances Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot)                  
                    {
                        if (instance == null) 
                            instance = new InMemoryInstances();
                    }
                }
                return instance;
            }
        }
        public bool checkToken(string token)
        {
            return activeTokens.Contains(new Guid(token));
        }
        public bool addToken(string token)
        {
            activeTokens.Add(new Guid(token));
            return true;
        }
        public bool removeToken(string token)
        {
            return activeTokens.Remove(new Guid(token));
        }
    }
