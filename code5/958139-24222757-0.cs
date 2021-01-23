    public static class StaticHelper
    {
        private static Object lockObject = new Object();
        private static string _nameStatic;
    
        public static string NameStatic { 
            get { lock (lockObject) return _nameStatic;  }
            set { lock (lockObject) _nameStatic = value; }
        }
    
        public static void MethodCountStatic(int num) {
            lock (lockObject) {
                // Your method here...
            }
        }
    }
