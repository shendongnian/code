    public class Something
    {
        private Dictionary<int, int> dic;
        private void Initialize()
        {
            dic = new Dictionary<int, int>();
        }
    
        public Something()
        {
            Initialize();
        }
    
        public Something(Dictionary<int, int> a)
        {
            Initialize();
            // do something with a??
            // Yes, you are not using the parameter "a".
            // I don't know if this is intentional.
        }
    }
