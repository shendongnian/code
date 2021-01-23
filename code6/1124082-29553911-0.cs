    public static class Util
    {
        public static string NameOf<TProperty>(Expression<Func<TProperty>> e)
        {
            return (e.Body as MemberExpression).Member.Name;
        }
    
        public static string NameOf<TClass, TProperty>(Expression<Func<TClass, TProperty>> e)
        {
            return (e.Body as MemberExpression).Member.Name;
        }
    }
