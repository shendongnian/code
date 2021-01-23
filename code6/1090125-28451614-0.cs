    public class DataModel
    {
        private readonly object s_lock= new object();
        private int _a;
        public int a {
        get {
            lock(s_lock) {
                return _a;
            }
        }
        set {
            lock(s_lock) {
                _a = value;
            }
        }
    }
