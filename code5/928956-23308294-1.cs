    var name = ExpressionTrees.GetPropertyName<MyClass, int>(x => x.MyProperty);
    ...
    public static class ExpressionTrees
    {
        public static string GetPropertyName<TSource, TTarget>
             (Expression<Func<TSource, TTarget>> expression)
        {
            ...
        }
    }
