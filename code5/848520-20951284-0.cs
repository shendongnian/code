    using System;
    
    public class Class1
    {
        private static readonly Class1 _myInstance = new Class1();
    
    	private Class1()
    	{
            // do your once custom code here
            // and possible do reflection to check if your custom attributes
            // are in use
    	}
    
        public static Class1 GetInstance()
        {
            get {
                return _myInstance;
            }
        }
    
    }
