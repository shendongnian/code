    using LightInject;
    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var container = new ServiceContainer();
                container.Register<IFoo, Foo>();
                container.Register<IBar, Bar>();
                var foo = container.GetInstance<IFoo>();
                foo.DoFooStuff();
            }
        }
        public interface IFoo
        {
            void DoFooStuff();
        }
        public class Foo : IFoo
        {
            // this property is automatically populated!
            public IBar MyBar { get; set; }
            public void DoFooStuff()
            {
                MyBar.DoBarStuff();
                Console.WriteLine("Foo is doing stuff.");
            }
        }
        public interface IBar
        {
            void DoBarStuff();
        }
        public class Bar : IBar
        {
            public void DoBarStuff()
            {
                Console.WriteLine("Bar is doing stuff.");
            }
        }
    }
