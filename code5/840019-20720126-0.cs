    public class Singleton
    {
        private static Singleton instance;
          
        // Private Constructor.
        private Singleton(0
        {
        }
        
        // Returns the instance of this class.
        public static Singleton getInstance()
        {
            // Check if an instance of this class already exists.
            if(instance == null)
               // It doesn't exist so create it. 
               instance = new Singleton();
            
            // Return the instance.
            return instance;
        }
    }
