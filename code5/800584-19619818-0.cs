    public class MyClass : IDisposable
    {
        public void MyCleanUpmethod(object p)
        {
           // My Clean up proccess here 
           ....
        }       
    
        public void Dispose()
        {
            MyCleanUpmethod(new object());
        }
    }
