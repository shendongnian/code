    public class MyGlobalClass
    {
        private Lazy<MyGlobalClass> _instance = new Lazy<MyGlobalClass>();
        public static MyGlobalClass Instance { get { return _instance.Value; } }
        //Whatever else, accessed by MyGlobalClass.Instance.<Whatever>
    }
