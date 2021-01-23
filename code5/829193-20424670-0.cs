    // Implements a variable-size List that uses an array of objects to store the
    // elements. A List has a capacity, which is the allocated length 
    // of the internal array. As elements are added to a List, the capacity
    // of the List is automatically increased as required by reallocating the
    // internal array.
    // 
    [DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
    [DebuggerDisplay("Count = {Count}")] 
    [Serializable] 
    public class List<T> : IList<T>, System.Collections.IList, IReadOnlyList<T>
