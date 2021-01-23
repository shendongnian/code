    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApplication6
    {
        // the utility code
    
        internal static class ExtensionMethodsHelper
        {
            private static readonly ConcurrentDictionary<Type, IDictionary<string, MethodInfo>> methodsMap = new ConcurrentDictionary<Type, IDictionary<string, MethodInfo>>();
    
            [MethodImpl(MethodImplOptions.Synchronized)]
            public static MethodInfo GetExtensionMethodOrNull(Type type, string methodName)
            {
                var methodsForType = methodsMap.GetOrAdd(type, GetExtensionMethodsForType);
                return methodsForType.ContainsKey(methodName)
                    ? methodsForType[methodName]
                    : null;
            }
    
            private static IDictionary<string, MethodInfo> GetExtensionMethodsForType(Type extendedType)
            {
                // WARNING! Two methods with the same name won't work here
                // for sake of example I ignore this fact
                // but you'll have to do something with that
    
                return AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Select(asm => GetExtensionMethods(asm, extendedType))
                                .Aggregate((a, b) => a.Union(b))
                                .ToDictionary(mi => mi.Name, mi => mi);
            }
    
            private static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extendedType)
            {
                var query = from type in assembly.GetTypes()
                            where type.IsSealed && !type.IsGenericType && !type.IsNested
                            from method in type.GetMethods(BindingFlags.Static
                                | BindingFlags.Public | BindingFlags.NonPublic)
                            where method.IsDefined(typeof(ExtensionAttribute), false)
                            where method.GetParameters()[0].ParameterType == extendedType
                            select method;
                return query;
            }
        }
    
        // example: class with extension methods
    
    
        public static class ExtensionMethods
        {
            public static string MyExtensionMethod(this string myString)
            {
                return "ranextension on string '" + myString + "'";
            }
        }
    
        // example: usage
    
        internal class Program
        {
            private static void Main()
            {
                var mi = ExtensionMethodsHelper.GetExtensionMethodOrNull(typeof(string), "MyExtensionMethod");
                if (mi != null)
                {
                    Console.WriteLine(mi.Invoke(null, new object[] { "hello world" }));
                }
                else
                {
                    Console.WriteLine("did't find extension method with name " + "MyExtensionMethod");
                }
            }
        }
    }
