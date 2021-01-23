    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace TestCompareProperties
    {
        class Program
        {
            class IgnorePropertyCompareAttribute : Attribute { }
    
            class A
            {
                public int Property1 { get; private set; }
                public string Property2 { get; private set; }
                [IgnorePropertyCompare]
                public bool Property3 { get; private set; }
    
                public A(int property1, string property2, bool property3)
                {
                    Property1 = property1;
                    Property2 = property2;
                    Property3 = property3;
                }
            }
    
            class PropertyCompareResult
            {
                public string Name { get; private set; }
                public object OldValue { get; private set; }
                public object NewValue { get; private set; }
    
                public PropertyCompareResult(string name, object oldValue, object newValue)
                {
                    Name = name;
                    OldValue = oldValue;
                    NewValue = newValue;
                }
            }
    
            private static List<PropertyCompareResult> Compare<T>(T oldObject, T newObject)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                List<PropertyCompareResult> result = new List<PropertyCompareResult>();
    
                foreach (PropertyInfo pi in properties)
                {
                    if (pi.CustomAttributes.Any(ca => ca.AttributeType == typeof(IgnorePropertyCompareAttribute)))
                    {
                        continue;
                    }
    
                    object oldValue = pi.GetValue(oldObject), newValue = pi.GetValue(newObject);
    
                    if (!object.Equals(oldValue, newValue))
                    {
                        result.Add(new PropertyCompareResult(pi.Name, oldValue, newValue));
                    }
                }
    
                return result;
            }
    
            static void Main(string[] args)
            {
                A[] rga = { new A(1, "1", false), new A(2, "1", true), new A(2, null, false) };
    
                for (int i = 0; i < rga.Length - 1; i++)
                {
                    Console.WriteLine("Comparing {0} and {1}:", i, i + 1);
                    foreach (PropertyCompareResult resultItem in Compare(rga[i], rga[i+1]))
                    {
                        Console.WriteLine("  Property name: {0} -- old: {1}, new: {2}",
                            resultItem.Name, resultItem.OldValue ?? "<null>", resultItem.NewValue ?? "<null>");
                    }
                }
            }
        }
    }
