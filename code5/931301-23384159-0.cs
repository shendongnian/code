    // Singleton
    public class Controller
    {
        // a Singleton has a private constructor
        private Controller()
        {
        }
        
        // this is the reference to the single instance
        private static Controller _Instance;
    
        // this is the static property to access the single instance
        public static Controller Instance
        {
            get
            {
                // if there is no instance then we create one here
                if (_Instance == null)
                    _Instance = new Controller();
                return _Instance;
            }
        }
    
        public void MyMethod(Computer computer, Recorder recoder)
        {
            // Do something here
        }
    }
