    using System.Collections.Concurrent;
    private static ConcurrentDictionary<Tuple<Type,Type>, bool> cache = new ConcurrentDictionary<Tuple<Type,Type>, bool>();
    public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic) {
        var input = Tuple.Create(toCheck, generic);
        bool isSubclass = cache.GetOrAdd(input, key => IsSubclassOfRawGenericInternal(toCheck, generic));
        return isSubclass;
    }
    private static bool IsSubclassOfRawGenericInternal(Type toCheck, Type generic) {
        while (toCheck != null && toCheck != typeof(object)) {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur) {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }
