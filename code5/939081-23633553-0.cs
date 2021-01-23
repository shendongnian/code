    public class MyClass : IDisposable
    {
       private WebServiceHost m_WebServiceHost;
       // Members
       public void Dispose()
       {
                ((IDisposable)m_WebServiceHost).Dispose();
       }
    }
