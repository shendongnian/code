    using System.Diagnostics;
    using System.Linq;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    namespace ConsoleApplication3
    {
        public class Root1
        {
            public Dep1 D1 { get; set; }
            public Dep1 D2 { get; set; }
            public Dep2 D3 { get; set; }
            public Dep2 D4 { get; set; }
        }
        public class Root2
        {
            public Dep1 D1 { get; set; }
            public Dep1 D2 { get; set; }
            public Dep2 D3 { get; set; }
            public Dep2 D4 { get; set; }
        }
        public class Dep1
        { 
        }
        public class Dep2
        { 
        }
        public class CustomScopeRootSelector
        {
            private readonly object[] _roots;
            public CustomScopeRootSelector(params object[] roots)
            {
                _roots = roots;
            }
            public IHandler Selector(IHandler[] resolutionStack)
            {
                return resolutionStack.FirstOrDefault(h => _roots.Contains(h.ComponentModel.Implementation));
            }
        }
        class Program
        {
            static void Main()
            {
                var container = new WindsorContainer();
                var rootSelector = new CustomScopeRootSelector(typeof (Root1), typeof (Root2));
                container.Register(
                   Component.For<Root1>().LifestyleTransient(),
                   Component.For<Root2>().LifestyleTransient(),
                   Component.For<Dep1>().LifestyleBoundTo(rootSelector.Selector),
                   Component.For<Dep2>().LifestyleBoundTo(rootSelector.Selector)
                   );
                var r1 = container.Resolve<Root1>();
                var r2 = container.Resolve<Root2>();
                Debug.Assert(r1.D1 == r1.D2);
                Debug.Assert(r1.D1 != r2.D1);
            }
        }
    }
