    public class GlobalObject {
        private static readonly GlobalObject _instance = new GlobalObject();
        
        public static GlobalObject SharedInstance { get { return _instance; } }
        public object SharedValue { get; set; }
    }
