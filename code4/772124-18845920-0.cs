    public class Settings
    {
        private string _access;
        
        public Settings()
        {
            _access = read from config;
        }
    
        public string Access { get { return _access; } }
    }
