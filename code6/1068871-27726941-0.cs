    public class Reference<T>
    {
        public T Value;
    }
    /* declaration */
    bool TryGetValues(
        this Dictionary<K,V> dict,
        params Tuple<K, Reference<V>>[] requests)
    /* call site */
    var x = new Reference<string>();
    var y = new Reference<string>();
    var z = new Reference<string>();
    bool foundAllEntries = myDictionary.TryGetValues(
        Tuple.Create("xvalue", x),
        Tuple.Create("yvalue", y), 
        Tuple.Create("zvalue", z));
