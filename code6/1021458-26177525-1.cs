     Singleton s = Singleton.GetInstance;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    ///
    
    
    //Lazy Initalization
    public  class Singleton
    {
        private static Singleton instance = null;
        private Singleton() { }
    
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
    
                return instance;
            }
        }
    }
