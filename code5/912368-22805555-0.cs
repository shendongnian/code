     public class AdapterWithLogging : IAdapter
     {
        Adaptee _adaptee = new Adaptee();
        public void MethodA()
        {
            LoggerStatic.Log("Calling Adaptee");
            _adaptee.MethodB();
        }
     }
