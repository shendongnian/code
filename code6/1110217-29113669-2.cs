    public class InMemoryInstances
    {
        private static volatile InMemoryInstances instance;
        private static object syncRoot = new Object();
        private List<Guid> activeTokens;
        private NameValueCollection filesByKeyCollection;
        private InMemoryInstances() 
        {
            activeTokens = new List<Guid>();
            filesByKeyCollection = new NameValueCollection();
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
        public string[] getFiles(string token)
        {
            return filesByKeyCollection.GetValues(token);
        }
        public bool addFiles(string token, string[] files)
        {
            for (int i = 0; i < files.Length; i++)
                filesByKeyCollection.Add(token, files[i]);
            return true;
        }
        public bool addToken(string token)
        {
            activeTokens.Add(new Guid(token));
            return true;
        }
        public bool removeFiles(string token)
        {
            filesByKeyCollection.Remove(token);
            return true;
        }
        public bool removeToken(string token)
        {
            return activeTokens.Remove(new Guid(token));
        }
    }
