    var doStuffMethod = [current type].GetMethod("DoStuff", BindingFlags.NonPublic | BindingFlags.Static)
        .GetGenericMethodDefinition()
        .MakeGenericMethod(type);
    doStuffMethod.Invoke(null, new object[] { context });
    
    private static void DoStuff<TEntity>(MainContext context) {
        // here you can do
        context.Set<TEntity>();
    }
