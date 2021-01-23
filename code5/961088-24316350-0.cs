    public static class Functional
    {
        public static Func<T, bool> Not<T>(this Func<T, bool> f)
        {
            return x => !f(x);
        }
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> f)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(f.Body), f.Parameters);
        }
    }
