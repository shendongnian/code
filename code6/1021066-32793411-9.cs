     [TestFixture]
    public class Try4
    {
        [Test]
        public void Can_create_interceptor()
        {
            var type = typeof (IServiceA);
            Assert.NotNull(new DefaultConventionWithProxyScanner().CreateInterceptor(type));
        }
        [Test]
        public void Can_create_policy()
        {
            var type = typeof (IServiceA);
            Assert.NotNull(new DefaultConventionWithProxyScanner().CreatePolicy(type));
        }
        [Test]
        public void Can_register_normally()
        {
            var container = new Container();
            container.Configure(x => x.Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            }));
            var serviceA = container.GetInstance<IServiceA>();
            Assert.IsFalse(ProxyUtil.IsProxy(serviceA));
            Console.WriteLine(serviceA.GetType());
        }
        [Test]
        public void Can_register_proxy_for_all()
        {
            var container = new Container();
            container.Configure(x => x.Scan(y =>
            {
                y.TheCallingAssembly();
                y.Convention<DefaultConventionWithProxyScanner>();
            }));
            var serviceA = container.GetInstance<IServiceA>();
            Assert.IsTrue(ProxyUtil.IsProxy(serviceA));
            Console.WriteLine(serviceA.GetType());
        }
        [Test]
        public void Make_sure_I_wait()
        {
            var container = new Container();
            container.Configure(x => x.Scan(y =>
            {
                y.TheCallingAssembly();
                y.Convention<DefaultConventionWithProxyScanner>();
            }));
            var serviceA = container.GetInstance<IServiceA>();
            serviceA.Wait();
        }
    }
    }
     public interface IServiceA
    {
        void Wait();
    }
    public class ServiceA : IServiceA
    {
        public void Wait()
        {
           Thread.Sleep(1000);
        }
    }
    public interface IServiceB
    {
        
    }
    public class ServiceB : IServiceB
    {
        
    }
