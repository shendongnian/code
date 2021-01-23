    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    // Proof that this makes the compiler happy.
    class Program
    {
        static void Main(string[] args)
        {
            // This is written to try to demonstrate an alternative,
            // type-clean way of handling http://stackoverflow.com/q/18641693/429091
            var x = "blah".ToDictionary(
                c => c,
                c => (int)c);
            // This would be where the ambiguity error would be thrown,
            // but since we explicitly extend Dictionary<TKey, TValue> dirctly,
            // we can write this with no issue!
            x.WriteTable(Console.Out, "a");
            var y = (IDictionary<char, int>)x;
            y.WriteTable(Console.Out, "b");
            var z = (IReadOnlyDictionary<char, int>)x;
            z.WriteTable(Console.Out, "lah");
        }
    }
    
    // But getting compile-time type safety requires so much code duplication!
    static class DictionaryExtensions
    {
        // Actual implementation against lowest common denominator
        public static void WriteTable<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TextWriter writer, IEnumerable<TKey> keys)
        {
            writer.WriteLine("-");
            foreach (var key in keys)
                // Access values by key lookup to prove that we’re interested
                // in the concept of an actual dictionary/map/lookup rather
                // than being content with iterating over everything.
                writer.WriteLine($"{key}:{dict[key]}");
        }
    
        // Use façade/adapter if provided IDictionary<TKey, TValue>
        public static void WriteTable<TKey, TValue>(this IDictionary<TKey, TValue> dict, TextWriter writer, IEnumerable<TKey> keys)
            => new ReadOnlyDictionaryWrapper<TKey, TValue>(dict).WriteTable(writer, keys);
    
        // Use an interface cast (a static known-safe cast).
        public static void WriteTable<TKey, TValue>(this Dictionary<TKey, TValue> dict, TextWriter writer, IEnumerable<TKey> keys)
            => dict.StaticCast<IReadOnlyDictionary<TKey, TValue>>().WriteTable(writer, keys);
    
        // Require known compiletime-enforced static cast http://stackoverflow.com/q/3894378/429091
        public static T StaticCast<T>(this T o) => o;
    }
    
    // The necessary class to provide an IReadOnlyDictionary<TKey, TValue>
    // façade around an IDictionary<TKey, TValue>. Because the BCL didn’t
    // use inheritence when it should have.
    class ReadOnlyDictionaryWrapper<TKey, TValue>
    : IReadOnlyDictionary<TKey, TValue>
    {
        public TValue this[TKey key] => Dictionary[key];
    
        public int Count => Dictionary.Count;
    
        public IEnumerable<TKey> Keys => Dictionary.Keys;
    
        public IEnumerable<TValue> Values => Dictionary.Values;
    
        IDictionary<TKey, TValue> Dictionary { get; }
    
        public ReadOnlyDictionaryWrapper(
            IDictionary<TKey, TValue> dictionary)
        {
            Dictionary = dictionary;
        }
    
        public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);
    
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
    
        public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);
    
        IEnumerator IEnumerable.GetEnumerator() => Dictionary.StaticCast<IEnumerable>().GetEnumerator();
    }
