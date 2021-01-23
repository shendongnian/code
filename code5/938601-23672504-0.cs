    using System.Collections.Generic;
    using System.Diagnostics;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    namespace ConsoleApplication1
    {
        public class IHelper
        {
        }
        public interface IMyClass
        {
            string SomeValue { get; }
        }
        public class MyClass : IMyClass
        {
            public string SomeValue { get; set; }
            public MyClass()
            {
                //do nothing related to SomeValue
            }
            public MyClass(IHelper helper)
            {
                SomeValue = "hello";
            }
        }
        class Program
        {
            static void Main()
            {
                var container = new WindsorContainer();
                var classParams = new Dictionary<string, string> { { "SomeValue", "A New Value" } };
                container.Register(
                  Component.For<IHelper>(),
                  Component.For<IMyClass>()
                    .ImplementedBy<MyClass>()
                    .DependsOn(classParams)
                    .Named("NamedInstanceGoesHere")
                    .LifestyleTransient());
                var myObject = container.Resolve<IMyClass>("NamedInstanceGoesHere");
                Debug.Assert(myObject.SomeValue == classParams["SomeValue"]);
            }
        }
    }
