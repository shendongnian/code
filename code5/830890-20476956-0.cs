    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace MvcApp
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class NullifyAttribute : Attribute
        {
        }
        public class PropertyNullifier
        {
            public static T Nullify<T>(T original)
                where T : class
            {
                // Limitations:
                // 1) only works for POCOs with public properties: t.GetProperties()
                // 2) only works for classes with public constructor
                // 3) it's not recursive
                Type t = original.GetType();
                // This looks for all the properties that are not marked with nullified
                List<PropertyInfo> notNullifiedProperties = 
                    t.GetProperties() // 1)
                    .Where(p => !p.GetCustomAttributes(typeof (NullifyAttribute), true).Any())
                    .ToList();
                // This creates an instance of the object
                T copy = Activator.CreateInstance<T>(); // 2)
                // And this copy the non-nullified properties
                foreach (var p in notNullifiedProperties)
                {
                    p.SetValue(copy, p.GetValue(original)); // 3) apply recursion to 2nd parameter
                }
                return copy;
            }
        }
    }
