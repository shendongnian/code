     public class Service1 : IService1
     {
        public string GetData(int value)
        {
            Thread.Sleep(5000);
            return "GOT HERE " + value;
        }
     }
