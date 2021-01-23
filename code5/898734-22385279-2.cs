    public class Methods : IMethods
    {
        // Singleton instance
        private static readonly IMethods _instance = new Methods();
        // Private constructor to enforce singleton
        private Methods()
        {
            
        }
        public void M1()
        {
            _instance.M1();
        }
        public void M2()
        {
            _instance.M2()
        }
    }
