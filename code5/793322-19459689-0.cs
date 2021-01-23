    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Linq;
    using DottedObjectMapper.Driver.Source;
    namespace DottedObjectMapper.Driver
    {
        internal static class Program
        {
            private static bool IsComplex(Type type)
            {
                if (type.IsPrimitive)
                {
                    return false;
                }
                if (type == typeof(decimal))
                {
                    return false;
                }
                if (type == typeof(string))
                {
                    return false;
                }
                if (type == typeof(DateTime))
                {
                    return false;
                }
                return true;
            }
            private static bool IsComplex(ParameterInfo parameter)
            {
                return IsComplex(parameter.ParameterType);
            }
            private static bool IsComplex(PropertyInfo property)
            {
                return IsComplex(property.PropertyType);
            }
            private static PropertyInfo[] GetUnderlyingProperties(PropertyInfo property)
            {
                Type propertyType = property.PropertyType;
                PropertyInfo[] properties = propertyType.GetProperties();
                return properties;
            }
            private static PropertyInfo[] GetAllProperties(PropertyInfo property)
            {
                PropertyInfo[] children = GetUnderlyingProperties(property);
                return GetAllProperties(children);
            }
            private static PropertyInfo[] GetAllProperties(PropertyInfo[] properties)
            {
                List<PropertyInfo> accumulator = new List<PropertyInfo>();
                foreach (PropertyInfo property in properties)
                {
                    accumulator.Add(property);
                    if (IsComplex(property))
                    {
                        PropertyInfo[] children = GetAllProperties(property);
                        accumulator.AddRange(children);
                    }
                }
                return accumulator.ToArray();
            }
            private static PropertyInfo[] GetAllProperties(Type type)
            {
                PropertyInfo[] properties = type.GetProperties();
                return GetAllProperties(properties);
            }
            private static void Main()
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["Birthdate"] = "John Doe";
                map["BillingAddress.FirstName"] = "I didn't know addresses had names.";
                map["BillingAddress.City"] = "Elsewhere";
                map["MailingAddress.House"] = "123";
                map["MailingAddress.City"] = "Nowhere";
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom("DottedObjectMapper.Driver.Source.dll");
                Type[] types = assembly.GetTypes();
                Type type = types.First((t) => t.Name == "Person");
                PropertyInfo[] properties = GetAllProperties(type);
                foreach (KeyValuePair<string, object> entry in map)
                {
                    string[] parts = entry.Key.Split('.');
                    PropertyInfo property = null;
                    foreach (string part in parts)
                    {
                        if (Object.ReferenceEquals(property, null))
                        {
                            property = properties.First((p) => p.Name == part);
                        }
                        else
                        {
                            property = properties.First((p) => p.Name == part && p.DeclaringType == property.PropertyType);
                        }
                    }
                    if (Object.ReferenceEquals(property, null))
                    {
                        // The path is invalid
                    }
                }
            }
        }
    }
