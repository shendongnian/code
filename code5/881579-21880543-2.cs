    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            void test()
            {
                List<KeyValuePair<string, object>> lKVP = new List<KeyValuePair<string, object>>();
                List<string> lS = new List<string> { "s1", "s2" };
                string[] aS = {"a1", "a2"};
                lKVP.Add(new KeyValuePair<string, object>("String", "E92D8719-38A6-0000-961F-0E66FCB0A363"));
                lKVP.Add(new KeyValuePair<string, object>("Test", lS));
                lKVP.Add(new KeyValuePair<string, object>("IntNotEnumerable", 12345));
                lKVP.Add(new KeyValuePair<string, object>("Array", aS));
                var listEnumerator  = this.GetType().GetMethod("enumerateList",  BindingFlags.NonPublic | BindingFlags.Static);
                var arrayEnumerator = this.GetType().GetMethod("enumerateArray", BindingFlags.NonPublic | BindingFlags.Static);
                foreach (KeyValuePair<string, object> kvp in lKVP)
                {
                    MethodInfo genericEnumerator = null;
                    var arrayElemType = arrayElementType(kvp.Value);
                    if (arrayElemType != null)
                    {
                        genericEnumerator = arrayEnumerator.MakeGenericMethod(arrayElemType);
                    }
                    else
                    {
                        var listElemType = listElementType(kvp.Value);
                        if (listElemType != null)
                            genericEnumerator = listEnumerator.MakeGenericMethod(listElemType);
                    }
                    if (genericEnumerator != null)
                        genericEnumerator.Invoke(null, new[] { kvp.Value });
                    else
                        Console.WriteLine("Not enumerating type: " + kvp.Value.GetType().FullName + "\n");
                }
            }
            static Type arrayElementType(object sequence)
            {
                if (sequence is IEnumerable)
                {
                    var type = sequence.GetType();
                    if (type.IsArray)
                        return type.GetElementType();
                }
                return null;
            }
            static Type listElementType(object sequence)
            {
                if (sequence is IEnumerable)
                {
                    var type = sequence.GetType();
                    if (typeof(IList).IsAssignableFrom(type) && type.IsGenericType)
                        return type.GetProperty("Item").PropertyType;
                }
                return null;
            }
            static void enumerateList<T>(List<T> list)
            {
                Console.WriteLine("Enumerating list of " + typeof(T).FullName);
                foreach (var item in list)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
            static void enumerateArray<T>(T[] array)
            {
                Console.WriteLine("Enumerating array of " + typeof(T).FullName);
                foreach (var item in array)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
            static void Main(string[] args)
            {
                new Program().test();
            }
        }
    }
