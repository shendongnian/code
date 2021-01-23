    var pInfos = new SomeObject().GetPropertyInfosExcept(x => x.obj, x => x.name)
                 .ToList();
----
    public static IEnumerable<PropertyInfo> GetPropertyInfosExcept<T>(
                              this T obj, params Expression<Func<T, object>>[] lambda)
    {
        HashSet<string> set = new HashSet<string>(
                lambda.Select(l => (l.Body as MemberExpression).Member as PropertyInfo)
                      .Select(x=>x.Name)
            );
        return typeof(T).GetProperties().Where(p => !set.Contains(p.Name));
    }
