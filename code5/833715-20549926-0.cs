    public class Something
    {
        private Dictionary<int, int> dic;
    
        public Something()
            : this(new Dictionary<int, int>())
        {
        }
    
        public Something(Dictionary<int, int> a)
        {
            dic = a;
        }
    }
