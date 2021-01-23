    using System;
     
    namespace DynaCacheSimpleInjector
    {
        using System.Threading;
 
    using DynaCache;
 
    using SimpleInjector;
 
    class Program
    {
        static void Main()
        {
            var container = new Container();
 
            container.RegisterSingle<IDynaCacheService>(new MemoryCacheService());
            container.Register(typeof(ITestClass), Cacheable.CreateType<TestClass>());
 
            var instance = container.GetInstance<ITestClass>();
 
            for (var i = 0; i < 10; i++)
            {
                // Every 2 seconds the output will change
                Console.WriteLine(instance.GetData(53));
                Thread.Sleep(500);
            }
        }
    }
 
    public class TestClass : ITestClass
    {
        [CacheableMethod(2)]
        public virtual string GetData(int id)
        {
            return String.Format("{0} - produced at {1}", id, DateTime.Now);
        }
    }
 
    public interface ITestClass
    {
        string GetData(int id);
    }
}
