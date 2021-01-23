    public class Service1 : IService1 {
        private static readonly object @lock = new object();
        public List<String> getBrute() {
           lock (@lock)
           {
               //method body
           }
        }
     }
