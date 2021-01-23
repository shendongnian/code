    public class DataModel
    {
        private readonly object _lock= new object();
        private int _a;
        public int a {
        get {
            lock(_lock) {
                return _a;
            }
        }
        set {
            lock(_lock) {
                _a = value;
            }
        }
    }
