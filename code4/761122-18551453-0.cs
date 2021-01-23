    public interface A
    {
        void DoA();
    }
    public interface B
    {
        void DoB();
    }
    public class IInterceptorX : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + " is beign invoked");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProxyGenerator();
            dynamic newObject = generator.CreateInterfaceProxyWithoutTarget(typeof(A), new Type[] { typeof(B) }, new IInterceptorX());
            Console.WriteLine(newObject is A); // True
            Console.WriteLine(newObject is B); // True
            newObject.DoA(); // DoA is being invoked
        }
    }
