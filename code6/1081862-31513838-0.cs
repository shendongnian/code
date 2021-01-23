    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product();
            var status = product.Process();
        }
    }
    public class Product : Provider
    {
        string provId = "ABC101";
        public bool Process()
        {
            var prodProv = new Provider(provId);
            this.QueryProvider();
            return true;
        }
    }
    public class Provider
    {
        private string _providerId;
        public Provider(string provId)
        {
            _providerId = provId;
        }
        public void QueryProvider()
        {
            // Execute Provider logic here
        }
    }
