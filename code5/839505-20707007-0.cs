    using System;
    using Microsoft.Practices.Unity;
    using Newtonsoft.Json;
    namespace TestGrounds
    {
        public class TestClass
        {
            #region Properties
            public int TestIntegerProperty { get; set; }
            public string TestStringProperty { get; set; }
            #endregion
        }
        internal class Program
        {
            #region Static Methods
            private static void Main(string[] args)
            {
                const string json =
                    @"{ TestIntegerProperty: 1, TestStringProperty: 'Hello', AnotherTestPropertyToIgnore: 'Sup' }";
                registerDependencyFromJson<TestClass>(json);
                Console.ReadKey();
            }
            private static void registerDependencyFromJson<T>(string json) where T: class, new()
            {
                var deserializedObject = JsonConvert.DeserializeObject<T>(json);
                var type = deserializedObject.GetType();
                var container = new UnityContainer();
                container.RegisterInstance(type, type.Name, deserializedObject, new ContainerControlledLifetimeManager());
            }
            #endregion
        }
    }
