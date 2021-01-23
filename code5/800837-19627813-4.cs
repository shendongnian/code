    #define DEBUG                  
    #define USE_ALTERNATE_METHOD       
    public class MyApplication
    {
        public MyApplication()
        {
            #if DEBUG
                RegressionTests.Run();
            #endif 
        }
    
        public void myMethod
        {
            #if USE_ALTERNATE_METHOD 
                // Do alternate stuff
                //do not execute the following. just return.
            #endif
                // Do regular stuff
            
        }
    }
