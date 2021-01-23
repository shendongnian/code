    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace DemoApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestClass testClass = new TestClass();
                Console.WriteLine("Return-Value: " + testClass.ReturnSomething("TestProperty", typeof(TestModel)));
                Console.WriteLine("Return-Value: " + testClass.ReturnSomething("AnotherTestProperty", typeof(TestModel)));
    
                Console.ReadLine();
            }
        }
    
        public class TestAttribute : Attribute
        {
            public string Value
            {
                get;
                set;
            }
        }
    
        public class TestModel
        {
            [TestAttribute(Value = "TestValue")]
            public TestClass TestProperty { get; set; }
    
            [TestAttribute(Value = "AnotherValue")]
            public TestClass AnotherTestProperty { get; set; }
        }
    
        public class TestClass
        {
            public string ReturnSomething(string propertyName, Type modelType)
            {
                string returnValue = "";
    
                foreach (var property in modelType.GetProperties())
                {
                    if (property.Name == propertyName)
                    {
                        // Find Attributes
                        Attribute[] cAttributes = property.GetCustomAttributes(true).OfType<Attribute>().ToArray();
    
                        if (cAttributes != null)
                        {
                            // Iterate throught all attributes
                            foreach (System.Attribute cAttribute in cAttributes)
                            {
                                if (cAttribute is TestAttribute)
                                {
                                    returnValue = (cAttribute as TestAttribute).Value;
                                    break; // Break after first
                                }
                            }
                        }
                    }
                }
    
                return returnValue;
            }
        }
    }
