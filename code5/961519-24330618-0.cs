    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity.Mvc;
    namespace ConsoleApplication2
    {
        class Program
        {
            public interface IService<T>
            {
                List<T> GetService();
            }
            public class Service<T> : IService<T>
            {
                public List<T> GetService()
                {
                    return new List<T>();
                }
            }
            static void Main(string[] args)
            {
                var container = new UnityContainer();
                container.RegisterType(typeof(IService<>), typeof(Service<>));
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
                var service = DependencyResolver.Current.GetService(typeof(IService<string>));
                Console.WriteLine(service.ToString());
                Console.ReadKey();
            }
        }
    }
