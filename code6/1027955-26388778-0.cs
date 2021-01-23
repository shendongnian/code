    public class MyClass
    {
        /// <summary>
        /// Get singleton instance of this class
        /// </summary>
        public static readonly MyClass Instance = new MyClass();
        
        static MyClass()
        {
            //causes the compiler to not mark this as beforefieldinit, giving this thread safety
            //for accessing the singleton.
        }
        
        //.. the rest of your stuff..
    }
