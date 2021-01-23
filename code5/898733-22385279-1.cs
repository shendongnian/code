    public class Methods : IMethods
    {
        // Singleton instance
        private static readonly IMethods _instance = new Methods();
        // Private constructor to enforce singleton
        private Methods()
        {
            
        }
        // The instance getter
        public static IMethods Instance
        {
            get
            {
                return _instance;
            }
        }
        public void M1()
        {
        }
        public void M2()
        {
        }
    }
