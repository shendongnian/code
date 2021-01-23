    public class SomeClass
    {
    FactoryTest factory; // instantiate this somewhere like constructor
    
    public void someMethod()
    {
    [...]
    var proxy = factory.getProxy(sServiceWsdl, sContract);
    [...]
    try {
       sXmlOUT = (String)proxy.CallMethod(sMethod, sXmlIN);
       //  proxy.Close(); - do not close connection
    catch (Exception e)
    {
       // Here appears the exception
    }
    }// end method
    }// end class
    
    // optionally if you want the same instance to server other callers
    // you can turn this into a Singleton pattern and return a shared 
    // static instance of FactoryTest via a static method. Do not forget to 
    // dispose of the singleton at the end of your application
    public sealed class FactoryTest : IDisposable
    {
        private object syncRoot = new Object();
        private Hashtable hashFactory = new Hashtable();
    
        public DynamicProxy getProxy(String sServiceWsdl, String sContract)
        {
            if (hashFactory[sServiceWsdl] == null || ((ProxyTest)hashFactory[sServiceWsdl]).getTimeFromCreation().TotalSeconds > 60 * 60 * 6)
            {
                lock (syncRoot)
                {
                    if (hashFactory[sServiceWsdl] == null || ((ProxyTest)hashFactory[sServiceWsdl]).getTimeFromCreation().TotalSeconds > 60 * 60 * 6)
                    {
                        hashFactory.Add(sServiceWsdl, new ProxyTest(sServiceWsdl, sContract));
                    }
                }
            }
    
            return ((ProxyTest)hashFactory[sServiceWsdl]).getProxy();
        }
    
        public bool isProxyExists(String sServiceWsdl, String sContract)
        {
            lock (syncRoot)
            {
                return hashFactory[sServiceWsdl] == null ? false : true;
            }
        }
    
    public void Dispose()
    {
    // implement IDisposable
    // dispose of everything hashFactory using Close() or Dispose()
    }
    
    } // end class
