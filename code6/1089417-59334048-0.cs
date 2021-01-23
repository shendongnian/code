    using System;
    using NUnit.Framework;
    using System.Collections.Concurrent;
    
    namespace MyProject.tests
    {
        public class ParentChildTest
        {
            [Test]
            public void dataAndMethodTest()
            {
                // add the data in parent project
                Parent.propertyCache["a"] = "b";
    
                // read the data in child project
                Console.WriteLine("Read from child: " + Child.getProperty("a"));
    
                // use Child project to call method of parent project
                Console.WriteLine("Call from child: Populate method in parent: " + Child.populate("c"));
            }
        }
    
        class Parent
        {
            // data is in Child project. Parent project just has the reference.
            public static ConcurrentDictionary<string, string> propertyCache = Child.getPropertyCache();
    
            public static string populate(string key)
            {
                //calculation
                string value = key + key;
                propertyCache[key] = value;
                return value;
            }
    
            // Pass the parent project method reference to child project
            public static int dummy = Child.setPopulateMethod(populate);
        }
    
        class Child
        {
            // data store
            static ConcurrentDictionary<string, string> propertyCache = new ConcurrentDictionary<string, string>();
    
            public static ConcurrentDictionary<string, string> getPropertyCache()
            {
                return propertyCache;
            }
    
            public static string getProperty(string key)
            {
                if (propertyCache.ContainsKey(key))
                {
                    return propertyCache[key];
                }
                return null;
            }
            
            // reference to parent project method
            static Func<string, string> populateMethodReference = null;
    
            public static int setPopulateMethod(Func<string, string> methodReference)
            {
                populateMethodReference = methodReference;
                return 0;
            }
    
            public static string populate(string key)
            {
                return populateMethodReference(key);
            }
        }
    }
