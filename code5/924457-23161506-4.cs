    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Dynamic;
    
    namespace ConsoleApplication11
    {
        class KeyAttribute : Attribute
        {
        }
        public class Example
        {
            [Key]
            public Guid FirstKey { get; set; }
    
            [Key]
            public Guid SecondKey { get; set; }
    
            public int UnimportantField { get; set; }
        }
    
        static class Program
        {
            static void Main(string[] args)
            {
                Example e = new Example()
                {
                    FirstKey = Guid.NewGuid(),
                    SecondKey = Guid.NewGuid(),
                    UnimportantField = 0
                };
    
                var func = e.GetKeyFunction<Example>();
    
                var key = func(e);
                Console.WriteLine(key.FirstKey);
                Console.WriteLine(key.SecondKey);
    
                Console.WriteLine(key.Equals(key));
                Console.WriteLine(key.GetHashCode());
                
                Example e2 = new Example()
                {
                    FirstKey = Guid.NewGuid(),
                    SecondKey = Guid.NewGuid(),
                    UnimportantField = 1
                };
    
                var key2 = func(e2);
                Console.WriteLine(key2.FirstKey);
                Console.WriteLine(key2.SecondKey);
                Console.WriteLine(key.Equals(key2));
                Console.WriteLine(key2.GetHashCode());
            }
    
            public static Func<T, dynamic> GetKeyFunction<T>(this T source)
            {
                return (t) =>
                    {
                        var dyn = (IDictionary<string, object>)new ExpandoObject();
                        foreach (var p in GetKeyProperties(typeof(T)))
                        {
                            dyn.Add(p.Name, p.GetValue(t));
                        }
                        dyn.Add("Equals", (Func<object, bool>)((o) => 
                            {
                                var comparer = new DictionaryComparer<string,object>();
                                return comparer.Equals(dyn as IDictionary<string,object>, o as IDictionary<string,object>);
                            }
                            ));
    
                        dyn.Add("GetHashCode", (Func<int>)(() =>
                            {
                                var comparer = new DictionaryComparer<string, object>();
                                return comparer.GetHashCode(dyn as IDictionary<string, object>);
                            }
                            ));
                        return dyn;
                    };
            }
    
            public static IEnumerable<PropertyInfo> GetKeyProperties(Type t)
            {
                PropertyInfo[] properties = t.GetProperties();
                return properties.Where(p => p.GetCustomAttributes<KeyAttribute>().Any());
            }
        }
    
         public class DictionaryComparer<TKey, TValue> : EqualityComparer<IDictionary<TKey, TValue>>
        {
            public DictionaryComparer()
            {
            }
            public override bool Equals(IDictionary<TKey, TValue> x, IDictionary<TKey, TValue> y)
            {
                // early-exit checks
                if (object.ReferenceEquals(x, y))
                    return true;
    
                if (null == x || y == null)
                    return false;
    
                if (x.Count != y.Count)
                    return false;
    
                // check keys are the same
                foreach (TKey k in x.Keys)
                    if (!y.ContainsKey(k))
                        return false;
    
                // check values are the same
                foreach (TKey k in x.Keys)
                {
                    TValue v = x[k];
                    if (object.ReferenceEquals(v, null))
                        return object.ReferenceEquals(y[k], null);
    
    
                    if (!v.Equals(y[k]))
                        return false;
                }
                return true;
            }
    
    
            public override int GetHashCode(IDictionary<TKey, TValue> obj)
            {
                if (obj == null)
                    return 0;
    
                int hash = 0;
    
                foreach (KeyValuePair<TKey, TValue> pair in obj)
                {
                    int key = pair.Key.GetHashCode(); // key cannot be null
                    int value = pair.Value != null ? pair.Value.GetHashCode() : 0;
                    hash ^= ShiftAndWrap(key, 2) ^ value;
                }
    
                return hash;
            }
    
    
            private static int ShiftAndWrap(int value, int positions)
            {
                positions = positions & 0x1F;
    
    
                // Save the existing bit pattern, but interpret it as an unsigned integer. 
                uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
                // Preserve the bits to be discarded. 
                uint wrapped = number >> (32 - positions);
                // Shift and wrap the discarded bits. 
                return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
            }
        }
    }
