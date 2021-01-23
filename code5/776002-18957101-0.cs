    class Program
    {
        static void Main(string[] args)
        {
            var proxyGenerator = new Castle.DynamicProxy.ProxyGenerator();
            var entity = proxyGenerator.CreateClassProxy(typeof(Article), new object[0], new TestInterceptor()) as Article; ;
            var json = JsonConvert.SerializeObject(entity);
        }
    }
    
    public class Article
    {
        public int Id { get; set; }
    }
    
    class TestInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
        }
    }   
