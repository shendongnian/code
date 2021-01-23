    MethodInfo castMethod = typeof(Enumerable).GetMethod("Cast", BindingFlags.Static | BindingFlags.Public);
    castMethod = castMethod.MakeGenericMethod(new Type[] { listType });
    object castIterator = castMethod.Invoke(null, new object[] { list});
    var toArrayMethod = typeof(Enumerable).GetMethod("ToArray", BindingFlags.Static | BindingFlags.Public);
    toArrayMethod = toArrayMethod.MakeGenericMethod(new Type[] { listType });
    object theArray = toArrayMethod.Invoke(null, new[] {castIterator});
