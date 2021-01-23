    namespace TestGrounds
    {
        public class TestClass
        {
            #region Properties
            public int TestIntegerProperty { get; set; }
            public string TestStringProperty { get; set; }
            #endregion
        }
        public class BadTestClass : TestClass
        {
            #region Properties
            public double TestDoubleProperty { get; set; }
            #endregion
            #region Constructors
            public BadTestClass(double testDouble)
            {
                TestDoubleProperty = testDouble;
            }
            #endregion
        }
        internal class Program
        {
            #region Static Methods
            private static void Main(string[] args)
            {
                const string json =
                    @"{ TestIntegerProperty: 1, TestStringProperty: 'Hello', AnotherTestPropertyToIgnore: 'Sup' }";
                var type = Type.GetType("TestGrounds.TestClass", true);
                var badType = Type.GetType("TestGrounds.BadTestClass", true);
                registerDependencyFromJson(type, json);
                try
                {
                    registerDependencyFromJson(badType, json);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
            private static void registerDependencyFromJson(Type type, string json)
            {
                // type requires a default constructor for this to work
                var constructor = type.GetConstructor(Type.EmptyTypes);
                if(constructor == null)
                {
                    throw new ArgumentException("Type must have a parameterless constructor.");
                }
                var deserializedObject = JsonConvert.DeserializeObject(json, type);
                var container = new UnityContainer();
                container.RegisterInstance(type, type.Name, deserializedObject, new ContainerControlledLifetimeManager());
            }
            #endregion
        }
    }
